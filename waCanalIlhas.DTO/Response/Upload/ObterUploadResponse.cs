﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace waCanalIlhas.DTO.Response.Upload
{
    [DataContract]
    public class ObterUploadResponse : BaseResponse
    {
        [DataMember]
        public string NomeUpload { get; set; }
    }
}
