using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;

namespace waCanalIlhas.Interface.Service
{
    public interface IUploadService
    {
        ObterUploadsResponse ObterUploads();
        ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest);
        DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest);
        SavarUploadResponse SalvarUpload(SavarUploadRequest pUploadSavarRequest);
    }
}
