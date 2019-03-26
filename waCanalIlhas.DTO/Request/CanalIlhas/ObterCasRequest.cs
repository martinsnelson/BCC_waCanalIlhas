using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Request.CanalIlhas
{
    [DataContract]
    public class ObterCasRequest : BaseRequest
    {
        [DataMember]
        public string Cas { get; set; }
    }
}
