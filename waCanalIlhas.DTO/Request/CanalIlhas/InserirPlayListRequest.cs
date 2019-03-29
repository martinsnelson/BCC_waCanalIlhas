using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using waCanalIlhas.DTO.CanalIlhas;

namespace waCanalIlhas.DTO.Request.CanalIlhas
{
    [DataContract]
    public class InserirPlayListRequest : BaseRequest
    {
        [DataMember]
        public PlayListDTO PlayList { get; set; }
    }
}
