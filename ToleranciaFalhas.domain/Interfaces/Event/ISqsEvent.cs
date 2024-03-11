using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Interfaces.Event
{

    public interface ISqsEvent
    {
        Task SendEventAsync(string queueUrl, string messageBody);
    }
   
}
