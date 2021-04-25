using System;
using System.Net;
using System.ServiceModel.Web;
using WcfService.Model;

namespace WcfService
{
    public class Service1 : IService
    {
        public Result GetData(Applicant applicant)
        {
            Result result;

            try
            {
                if (applicant == null)
                {
                    throw new ArgumentNullException(nameof(applicant));
                }

                if (string.IsNullOrWhiteSpace(applicant?.Name))
                {
                    throw new ArgumentNullException(nameof(applicant.Name));
                }

                if (string.IsNullOrWhiteSpace(applicant?.Age))
                {
                    throw new ArgumentNullException(nameof(applicant.Age));
                }

                var isAgeOk = int.TryParse(applicant?.Age, out var age);
                if (!isAgeOk || age > 200 || age < 0)
                {
                    throw new Exception($"{nameof(applicant.Age)} should be value 0-200");
                }

                result = new Result
                {
                    Applicant = applicant,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                // todo: what ever logging of the message for investigation
                result = new Result
                {
                    Applicant = applicant,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = e.Message
                };
            }

            return result;
        }

        public string GetDataException(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(nameof(name));
                }
            }
            catch (Exception e)
            {
                throw new WebFaultException<string>($"Exception: '{e.Message}'", HttpStatusCode.BadRequest);
            }

            return name;
        }

    }
}
