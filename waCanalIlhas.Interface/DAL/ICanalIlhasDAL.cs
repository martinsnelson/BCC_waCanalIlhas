using System.Collections.Generic;
using waCanalIlhas.DTO.CanalIlhas;
using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.Interface.DAL
{
    public interface ICanalIlhasDAL
    {
        IEnumerable<CasDTO> ObterListaCas();
        CasDTO ObterCas(int pObterCasRequest);
    }
}
