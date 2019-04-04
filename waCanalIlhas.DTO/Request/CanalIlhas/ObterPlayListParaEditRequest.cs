using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Request.CanalIlhas
{
    [DataContract]
    public class ObterPlayListParaEditRequest : BaseRequest
    {
        [DataMember]
        public int IdPlayList { get; set; }
    }
}
