using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;

namespace waCanalIlhas.ServiceAgent
{
    public class UploadServiceAgent
    {
        public UploadSavarResponse SalvarUpload(UploadSavarRequest pUploadSalvarRequest)
        {
            return Http.Post<UploadSavarResponse>("v1/api/Upload/SalvarUpload", pUploadSalvarRequest);
        }
    }
}
