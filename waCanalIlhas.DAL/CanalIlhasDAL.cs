using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
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

        public List<ArquivosDTO> ListaVideos()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT AU.NM_ARQUIVO_UPLOAD, AU.TP_ARQUIVO_UPLOAD FROM TB_CILHAS_ARQUIVO_UPLOAD AU WHERE AU.TP_ARQUIVO_UPLOAD IN ('.wmv', '.mp4', '.mpeg-4', '.avi')";
                var sSqlRetorno = conexao.Query<ArquivosDTO>(sSql).ToList();
                return sSqlRetorno;
            }
        }

        public List<ArquivosDTO> ListaImagens()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT AU.NM_ARQUIVO_UPLOAD, AU.TP_ARQUIVO_UPLOAD FROM TB_CILHAS_ARQUIVO_UPLOAD AU WHERE AU.TP_ARQUIVO_UPLOAD IN ('.jpg', '.jpeg', '.png', '.gif', '.bmp', '.pps', '.pdf', '.jpg')";
                var sSqlRetorno = conexao.Query<ArquivosDTO>(sSql).ToList();
                return sSqlRetorno;
            }
        }

        public IEnumerable<PlayListDTO> ObterPlayList()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                return conexao.GetAll<PlayListDTO>();
            }
        }
    }
}
