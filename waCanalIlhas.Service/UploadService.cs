using System;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;
using waCanalIlhas.Interface.DAL;
using waCanalIlhas.Interface.Service;
using waCanalIlhas.Service.Messages;

namespace waCanalIlhas.Service
{
    public class UploadService : IUploadService
    {
        private readonly IUploadDAL _uploadDAL;

        public UploadService(IUploadDAL uploadDAL)
        {
            _uploadDAL = uploadDAL;
        }

        public ObterUploadsResponse ObterUploads()
        {
            try
            {
                var lUploads = _uploadDAL.ObterUploads();
                return new ObterUploadsResponse{ Uploads = lUploads };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest)
        {
            try
            {
                return _uploadDAL.ObterUpload(pObterUploadRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest)
        {
            try
            {
                var deletarArquivo = _uploadDAL.DeletarArquivo(pDeletarUploadRequest);
                return new DeletarUploadResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public SavarUploadResponse SalvarUpload(SavarUploadRequest pUploadSalvarRequest)
        {
            try
            {
                var salvarUpload = _uploadDAL.SalvarUpload(pUploadSalvarRequest);
                return new SavarUploadResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
