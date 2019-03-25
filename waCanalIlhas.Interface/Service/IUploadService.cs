using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;

namespace waCanalIlhas.Interface.Service
{
    public interface IUploadService
    {
        ObterUploadsResponse ObterUploads();
        ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest);
        SavarUploadResponse SalvarUpload(SavarUploadRequest pUploadSavarRequest);
    }
}
