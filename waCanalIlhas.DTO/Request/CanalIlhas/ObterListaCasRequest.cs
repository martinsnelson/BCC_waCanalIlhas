using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Request.CanalIlhas
{
    [DataContract]
    public class ObterListaCasRequest : BaseRequest
    {
        [DataMember]
        public string Cas { get; set; }
    }
}
