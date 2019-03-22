using System.Threading.Tasks;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.Interface.DAL
{
    public interface IUploadDAL
    {
        //IEnumerable<Tarefa> ObterUploads();
        //Task<Tarefa> ObterUpload(long id);
        Task<UploadDTO> SalvarUpload(UploadSavarRequest pUploadSavarRequest);
        //Task<Tarefa> AlterarUpload(Tarefa tarefa);
        //Task<bool> DeletarUpload(long id);
    }
}
