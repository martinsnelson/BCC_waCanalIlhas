﻿using System.Runtime.Serialization;
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
