using System.Runtime.Serialization;

namespace WcfService.Model
{
    [DataContract]
    public class Applicant
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Age { get; set; }
    }
}