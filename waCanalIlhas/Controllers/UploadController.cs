using Microsoft.AspNetCore.Mvc;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;
using waCanalIlhas.Interface.Service;

namespace waCanalIlhas.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        public UploadSavarResponse SalvarUpload([FromBody] UploadSavarRequest pUploadSavarRequest)
        {
            return _uploadService.SalvarUpload(pUploadSavarRequest);
        }
    }
}