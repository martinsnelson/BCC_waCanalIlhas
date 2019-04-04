using System.Collections.Generic;
using System.Runtime.Serialization;
using waCanalIlhas.DTO.CanalIlhas;

namespace waCanalIlhas.DTO.Response.CanalIlhas
{
    [DataContract]
    public class ObterPlayListParaEditResponse : BaseResponse
    {
        [DataMember]
        public IEnumerable<PlayListDTO> PlayList { get; set; }
    }
}
