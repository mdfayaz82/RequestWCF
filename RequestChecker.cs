using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
namespace RequestSampleWPF
{


    public class RequestChecker
    {
        private Timer _timer;
        private readonly IRequestService _serviceClient;

        public RequestChecker(IRequestService serviceClient)
        {
            _serviceClient = serviceClient;
            _timer = new Timer(CheckRequests, null, 0, 10000); // Run every 10 seconds
        }

        private void CheckRequests(object state)
        {
            var requests = _serviceClient.CheckForRequests();
            if (requests.Any())
            {
                Console.WriteLine("New pending requests available!");
            }
        }
    }
}