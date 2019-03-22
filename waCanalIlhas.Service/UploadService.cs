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

        public UploadSavarResponse SalvarUpload(UploadSavarRequest pUploadSalvarRequest)
        {
            try
            {
                var salvarUpload = _uploadDAL.SalvarUpload(pUploadSalvarRequest);
                return new UploadSavarResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
