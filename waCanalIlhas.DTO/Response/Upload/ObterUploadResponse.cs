using System.Collections.Generic;
using System.Runtime.Serialization;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.DTO.Response.Upload
{
    [DataContract]
    public class ObterUploadResponse : BaseResponse
    {
        [DataMember]
        public IList<UploadDTO> Uploads { get; set; }
    }
}
