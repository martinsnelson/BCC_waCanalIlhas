using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Int64 InserirPlayList(InserirPlayListRequest pInserir)
        {   
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT SQ_CILHAS_UPLOAD_PLAYLIST.NEXTVAL FROM DUAL";
                Int64 SQ = conexao.QueryFirstOrDefault<Int64>(sSql, null);

                    sSql = "SELECT SQ_CILHAS_UPLOAD_PLAYLIST.NEXTVAL FROM DUAL";
                Int64 SQRel = conexao.QueryFirstOrDefault<Int64>(sSql, null);

                //remover
                var rafa = new PlayListDTO { ID_PLAYLIST = Convert.ToInt32(SQ), NM_PLAYLIST = "Nelson", TP_PLAYLIST = ".mp4" };

                conexao.Open();
                OracleCommand command = conexao.CreateCommand();
                OracleTransaction transaction = conexao.BeginTransaction();

                sSql = "INSERT INTO TB_CILHAS_PLAYLIST(ID_PLAYLIST, NM_PLAYLIST, TP_PLAYLIST) values(:ID_PLAYLIST, :NOME, :TP_ARQUIVO)";
                            //var sql = "update Widget set Quantity = @quantity where WidgetId = id";
                            //var parameters = new { ID_PLAYLIST = pInserir.PlayList.ID_PLAYLIST,
                            //    pInserir.PlayList.NM_PLAYLIST, pInserir.PlayList.TP_PLAYLIST
                            //};
                var pTranparameters = new { ID_PLAYLIST = rafa.ID_PLAYLIST, NOME = rafa.NM_PLAYLIST, TP_ARQUIVO = rafa.TP_PLAYLIST };
                conexao.Execute(sSql, pTranparameters, transaction);

                var rafa2 = new PlayListDTO { ID_PLAYLIST = Convert.ToInt32(SQ), NM_PLAYLIST = "Nelson", TP_PLAYLIST = ".mp4" };

                sSql = "INSERT INTO TB_CILHAS_UPLOAD_PLAYLIST(ID_UPLOAD_PLAYLIST, CD_ARQUIVO_UPLOAD, CD_PLAYLIST) values(:ID_UPLOAD_PLAYLIST, :CD_ARQUIVO_UPLOAD, :CD_PLAYLIST)";

                var sTranparameters = new { ID_UPLOAD_PLAYLIST = Convert.ToInt32(SQRel), CD_ARQUIVO_UPLOAD = 95, CD_PLAYLIST = rafa.ID_PLAYLIST };
                conexao.Execute(sSql, sTranparameters, transaction);

                transaction.Commit();
                        
                //transaction.Rollback();

                return SQ;
            }
        }
        

        //public Int64 InserirPlayList(InserirPlayListRequest pInserirPlayListRequest)
        //{
        //    //public System.Data.OracleClient.OracleTransaction BeginTransaction();

        //    using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
        //    {
        //        conexao.Open();
        //        OracleCommand command = conexao.CreateCommand();
        //        OracleTransaction transaction;

        //        //transaction = conexao.BeginTransaction(IsolationLevel.ReadCommitted);
        //        transaction = conexao.BeginTransaction();
        //        command.Connection = conexao;
        //        command.Transaction = transaction;

        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "SELECT SQ_CILHAS_PLAYLIST.NEXTVAL FROM DUAL";
        //        long id_PLAYLIST = Convert.ToInt64(command.ExecuteScalar());
        //        command.CommandText = "SELECT SQ_CILHAS_UPLOAD_PLAYLIST.NEXTVAL FROM DUAL";
        //        long id_UPLOAD_PLAYLIST = Convert.ToInt64(command.ExecuteScalar());

        //        //var id_ARQUIVO_UPLOAD = Convert.ToInt64("SELECT SQ_CILHAS_ARQUIVO_UPLOAD.NEXTVAL FROM DUAL");
        //        //var sSql = "SELECT SQ_CILHAS_ARQUIVO_UPLOAD.NEXTVAL FROM DUAL";
        //        //var id_ARQUIVO_UPLOAD = Convert.ToInt64(command.(sSql));
        //        //var transaction = conexao.BeginTransaction();
        //        try
        //        {
        //            command.CommandText = "INSERT INTO TB_CILHAS_PLAYLIST (ID_PLAYLIST, NM_PLAYLIST, TP_PLAYLIST) values (" + id_PLAYLIST + ", 'PLayTest', 'TP_Teste')";
        //            command.ExecuteNonQuery();

        //            command.CommandText = "INSERT INTO TB_CILHAS_UPLOAD_PLAYLIST (ID_UPLOAD_PLAYLIST, CD_ARQUIVO_UPLOAD, CD_PLAYLIST) values (" + id_UPLOAD_PLAYLIST + ", 1, " + id_PLAYLIST + ")";
        //            command.ExecuteNonQuery();

        //            transaction.Commit();

        //            Console.WriteLine("Ambos os registros são gravados no banco de dados.");
        //        }
        //        catch (Exception e)
        //        {
        //            transaction.Rollback();
        //            Console.WriteLine(e.ToString());

        //            Console.WriteLine("Nenhum registro foi gravado no banco de dados.");
        //        }
        //        return id_PLAYLIST;
        //    }
        //}
    }
}
