using System;
using System.Linq;

namespace RequestWCFService
{
    public class RequestService : IRequestService
    {
        public string CheckForRequests()
        {
            using (var context = new RequestDBContext())
            {
                var pendingRequest = context.Requests.FirstOrDefault(r => r.Status == 0);
                return pendingRequest == null ? "No requests to process." : $"Request {pendingRequest.RequestID} is pending.";
            }
        }

        public string UpdateRequest(int requestID, bool approve)
        {
            using (var context = new RequestDBContext())
            {
                var request = context.Requests.FirstOrDefault(r => r.RequestID == requestID);
                if (request == null)
                {
                    return "Request not found.";
                }

                request.Status = approve ? 1 : 2;
                request.UpdatedAt = DateTime.Now;
                context.SaveChanges();

                return $"Request {requestID} has been {(approve ? "approved" : "rejected")}.";
            }
        }
    }
}
