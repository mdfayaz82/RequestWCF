using System.ServiceModel;

namespace RequestWCFService
{
    [ServiceContract]
    public interface IRequestService
    {
        [OperationContract]
        string CheckForRequests();

        [OperationContract]
        string UpdateRequest(int requestID, bool approve);
    }
}
