using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.Interface.DAL
{
    public interface IUploadDAL
    {
        IList<UploadDTO> ObterUploads();
        ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest);
        //Task<Tarefa> ObterUpload(long id);
        Int64 SalvarUpload(SavarUploadRequest pUploadSavarRequest);
        //Task<Tarefa> AlterarUpload(Tarefa tarefa);
        DeletarUploadResponse DeletarUpload(DeletarUploadRequest pDeletarUploadRequest);
    }
}
