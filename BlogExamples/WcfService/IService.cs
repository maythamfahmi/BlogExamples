using System.ServiceModel;
using System.Web.Services.Description;
using WcfService.Model;

namespace WcfService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Result GetData(Applicant applicant);

        [OperationContract]
        string GetDataException(string name);
    }
}
