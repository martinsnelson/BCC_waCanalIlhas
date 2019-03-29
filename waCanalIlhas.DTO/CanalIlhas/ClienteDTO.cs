using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    public class ClienteDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}
