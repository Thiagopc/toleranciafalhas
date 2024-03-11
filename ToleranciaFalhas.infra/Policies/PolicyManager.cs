using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Timeout;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.infra.Policies
{
    public static class PolicyManager<T> where T : class
    {
        private static AsyncCircuitBreakerPolicy _circuitBreakerWrite;
        private static AsyncCircuitBreakerPolicy<List<T>> _circuitBreakerRead;


        public static AsyncPolicyWrap<List<T>> ObterPoliticaDeFallbackComTimeoutRead(Func<CancellationToken, Task<List<T>>> fallbackAction, int time = 1500, int timeCircuit = 50)
        {
            var fallback = Policy<List<T>>
                 .Handle<Exception>()
                 .FallbackAsync(fallbackAction);


            var timeout = Policy.
                TimeoutAsync<List<T>>
                (TimeSpan.FromMilliseconds(time), TimeoutStrategy.Pessimistic);

            if (_circuitBreakerRead == null)
                _circuitBreakerRead = Policy<List<T>>.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeCircuit));


            return fallback.WrapAsync(_circuitBreakerRead).WrapAsync(timeout);
        }


        public static AsyncPolicyWrap ObterPoliticaDeFallbackComTimeoutWrite(Func<CancellationToken, Task> fallbackAction, int time = 1500, int timeCircuit = 50)
        {
            var fallback = Policy
                 .Handle<Exception>()
                 .FallbackAsync(fallbackAction);


            var timeout = Policy.
                TimeoutAsync
                (TimeSpan.FromMilliseconds(time), TimeoutStrategy.Pessimistic);


            var retry = Policy.Handle<Exception>()
            .WaitAndRetryAsync(1, retryAttempt =>
            TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)) +
            TimeSpan.FromMilliseconds(new Random().Next(0, 100)) // Adiciona jitter entre 0 e 100 milissegundos
    );

            if (_circuitBreakerWrite == null)
                _circuitBreakerWrite = Policy.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeCircuit));

            return fallback.WrapAsync(_circuitBreakerWrite).WrapAsync(retry).WrapAsync(timeout);
        }


    }
}
