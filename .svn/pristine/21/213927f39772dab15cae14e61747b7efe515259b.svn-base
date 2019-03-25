using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;

namespace waCanalIlhas.ServiceAgent
{
    public class UploadServiceAgent
    {
        public ObterUploadsResponse ObterUploads()
        {
            return Http.Get<ObterUploadsResponse>("v1/api/Upload/ObterUploads");
        }

        public ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest)
        {
            return Http.Post<ObterUploadResponse>("v1/api/Upload/ObterUpload", pObterUploadRequest);
        }

        public DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest)
        {
            return Http.Post<DeletarUploadResponse>("v1/api/Upload/DeletarArquivo", pDeletarUploadRequest);
        }

        public SavarUploadResponse SalvarUpload(SavarUploadRequest pUploadSalvarRequest)
        {
            return Http.Post<SavarUploadResponse>("v1/api/Upload/SalvarUpload", pUploadSalvarRequest);
        }
    }
}
