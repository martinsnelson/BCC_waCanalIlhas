﻿using System.Runtime.Serialization;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.DTO.Request.Upload
{
    [DataContract]
    public class UploadSavarRequest : BaseRequest
    {
        [DataMember]
        public UploadDTO Upload { get; set; }
    }
}
