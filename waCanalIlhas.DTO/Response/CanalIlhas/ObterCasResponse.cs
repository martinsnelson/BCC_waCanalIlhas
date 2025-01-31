﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using waCanalIlhas.DTO.CanalIlhas;

namespace waCanalIlhas.DTO.Response.CanalIlhas
{
    [DataContract]
    public class ObterCasResponse :BaseResponse
    {
        [DataMember]
        public CasDTO Cas { get; set; }
    }
}
