using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;

namespace waCanalIlhas.Interface.Service
{
    public interface IUploadService
    {
        UploadSavarResponse SalvarUpload(UploadSavarRequest pUploadSavarRequest);
    }
}
