using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
using waCanalIlhas.DTO.CanalIlhas;
using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;
using waCanalIlhas.Interface.DAL;

namespace waCanalIlhas.DAL
{
    public class CanalIlhasDAL : ICanalIlhasDAL
    {
        private readonly IConfiguration _configuration;

        public CanalIlhasDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<CasDTO> ObterListaCas()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                return conexao.GetAll<CasDTO>();
            }
        }

        public CasDTO ObterCas(int pObterCasRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                //return conexao.Get<CasDTO>(pObterCasRequest);
                return conexao.QueryFirstOrDefault<CasDTO>(
                   "SELECT SL.ID_LOCAL, SL.NM_SIGLA " +
                   "FROM TB_SIN_LOCAL SL " +
                   "WHERE SL.ID_LOCAL = :ID_LOCAL",
                   new { ID_LOCAL = pObterCasRequest });
            }
        }
    }
}
