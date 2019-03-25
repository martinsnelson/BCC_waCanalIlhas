using System.Runtime.Serialization;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.DTO.Request.Upload
{
    [DataContract]
    public class SavarUploadRequest : BaseRequest
    {
        [DataMember]
        public UploadDTO Upload { get; set; }
    }
}
