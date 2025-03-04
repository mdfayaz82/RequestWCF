using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using RequestSample;
using RequestSample.Models;

namespace RequestSampleWPF
{

    [ServiceContract]
    public interface IRequestService
    {
        [OperationContract]
        List<Request> CheckForRequests();

        [OperationContract]
        bool UpdateRequest(int requestID, bool approve);
    }

    public class RequestService : IRequestService
    {
        public List<Request> CheckForRequests()
        {
            using (var db = new RequestDBContext())
            {
                return db.Requests.Where(r => r.Status == 0).ToList();
            }
        }

        public bool UpdateRequest(int requestID, bool approve)
        {
            using (var db = new RequestDBContext())
            {
                var request = db.Requests.Find(requestID);
                if (request == null) return false;

                request.Status = approve ? 1 : 2;
                request.UpdatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }
    }
}