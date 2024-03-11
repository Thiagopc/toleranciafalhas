using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Interfaces.Event;

namespace ToleranciaFalhas.infra.SqsEvent
{
    public class SqsEvent : ISqsEvent
    {

        private readonly IAmazonSQS _sqsClient;

        public SqsEvent(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient ?? throw new ArgumentNullException(nameof(sqsClient));
        }

        public async Task SendEventAsync(string queueUrl, string messageBody)
        {
            if (string.IsNullOrEmpty(queueUrl))
                throw new ArgumentException("Queue URL cannot be null or empty", nameof(queueUrl));

            if (string.IsNullOrEmpty(messageBody))
                throw new ArgumentException("Message body cannot be null or empty", nameof(messageBody));

            var request = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = messageBody,
                MessageGroupId = "10",
                MessageDeduplicationId = "21"
               
            };

            await _sqsClient.SendMessageAsync(request);
        }
    }
}
