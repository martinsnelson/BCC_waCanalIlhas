using Microsoft.AspNetCore.Mvc;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;
using waCanalIlhas.Interface.Service;

namespace waCanalIlhas.Controllers
{
    [Route("v1/api/[controller]/[action]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpGet]
        public ObterUploadsResponse ObterUploads()
        {
            return _uploadService.ObterUploads();
        }

        [HttpPost]
        public ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest)
        {
            return _uploadService.ObterUpload(pObterUploadRequest);
        }

        [HttpPost]
        public DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest)
        {
            return _uploadService.DeletarArquivo(pDeletarUploadRequest);
        }

        [HttpPost]
        public SavarUploadResponse SalvarUpload([FromBody] SavarUploadRequest pUploadSavarRequest)
        {
            return _uploadService.SalvarUpload(pUploadSavarRequest);
        }
    }
}