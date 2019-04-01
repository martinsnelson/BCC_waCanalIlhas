using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Response
{
    [DataContract]
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            Sucesso = true;
        }

        [DataMember]
        public string Mensagem { get; set; }

        [DataMember]
        public bool Sucesso { get; set; }
    }
}
