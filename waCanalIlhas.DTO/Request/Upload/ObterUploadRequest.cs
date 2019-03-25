using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace waCanalIlhas.DTO.Request.Upload
{
    [DataContract]
    public class ObterUploadRequest : BaseRequest
    {
        [DataMember]
        public string NomeUpload { get; set; }
    }
}
