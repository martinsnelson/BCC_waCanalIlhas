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
        DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest);
        Int64 SalvarUpload(SavarUploadRequest pUploadSavarRequest);
        //Task<Tarefa> AlterarUpload(Tarefa tarefa);
        //Task<Tarefa> ObterUpload(long id);
    }
}
