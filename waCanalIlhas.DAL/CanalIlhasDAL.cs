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
                var sSql = "SELECT AU.ID_ARQUIVO_UPLOAD, AU.NM_ARQUIVO_UPLOAD, AU.TP_ARQUIVO_UPLOAD FROM TB_CILHAS_ARQUIVO_UPLOAD AU WHERE AU.TP_ARQUIVO_UPLOAD IN ('.wmv', '.mp4', '.mpeg-4', '.avi')";
                return conexao.Query<ArquivosDTO>(sSql).ToList();
            }
        }

        public List<ArquivosDTO> ListaImagens()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT AU.ID_ARQUIVO_UPLOAD, AU.NM_ARQUIVO_UPLOAD, AU.TP_ARQUIVO_UPLOAD FROM TB_CILHAS_ARQUIVO_UPLOAD AU WHERE AU.TP_ARQUIVO_UPLOAD IN ('.jpg', '.jpeg', '.png', '.gif', '.bmp', '.pps', '.pdf', '.jpg')";
                return conexao.Query<ArquivosDTO>(sSql).ToList();                
            }
        }

        //public List<PlayListDTO> ObterPlayListParaEdit()
        //{
        //    //Int64 a = 1;
        //    using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
        //    {
        //        var sSql = "SELECT CP.ID_PLAYLIST, CP.NM_PLAYLIST, NM_CAS,  CP.TP_PLAYLIST, CP.FL_PLAYLIST_ATIVO, CP.NU_TAMANHO_PLAYLIST, " +
        //                    "CP.NM_CAMINHO_PLAYLIST, CP.NU_MATR_EXCLUSAO,  CP.DT_EXCLUSAO_PLAYLIST, " +
        //                    "CUP.ID_UPLOAD_PLAYLIST, CUP.CD_ARQUIVO_UPLOAD, CUP.CD_PLAYLIST, CUP.NU_ORDEM_EXIBICAO, " +
        //                    "CAU.ID_ARQUIVO_UPLOAD, CAU.NM_ARQUIVO_UPLOAD " +
        //                    "FROM TB_CILHAS_PLAYLIST CP " +
        //                    "JOIN TB_CILHAS_UPLOAD_PLAYLIST CUP ON CP.ID_PLAYLIST = CUP.CD_PLAYLIST " +
        //                    "JOIN TB_CILHAS_ARQUIVO_UPLOAD CAU ON CAU.ID_ARQUIVO_UPLOAD = CUP.CD_ARQUIVO_UPLOAD ";
        //        //var sSqlRetorno = conexao.AsList<PlayListDTO>(sSql, null, CommandType: CommandType.Text);
        //        //var sSqlRetorno = conexao.Execute(sSql, null, commandType: CommandType.Text);
        //        var sSqlRetorno = conexao.Query<PlayListDTO>(sSql).ToList();
        //        //var executeSql = conexao.Execute(sSql, null, commandType: CommandType.Text);
        //        // connection.Query<MyClass,MyClass,Match>(sqlhere,(mc1,mc2)=>{ var match = new Match(); match.Left = mc1; match.Right = mc2; return match; }); 
        //        return sSqlRetorno;
        //    }
        //}

        public IEnumerable<PlayListDTO> ObterPlayList()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                return conexao.GetAll<PlayListDTO>();
            }
        }

        public List<PlayListDTO> ObterPlayListParaEdit()
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sql =
                        "SELECT C.ID_PLAYLIST, C.NM_PLAYLIST, C.FL_PLAYLIST_ATIVO, " +
                        "A.ID_UPLOAD_PLAYLIST, A.CD_ARQUIVO_UPLOAD, A.NU_ORDEM_EXIBICAO " +
                        "FROM TB_CILHAS_PLAYLIST C " +
                        "JOIN TB_CILHAS_UPLOAD_PLAYLIST A ON A.CD_PLAYLIST = C.ID_PLAYLIST ";

                return conexao.Query<PlayListDTO, UploadPlayListRelDTO, PlayListDTO>(sql, (PlayList, UploadPlayListRel) =>
                {
                    PlayList.UploadPlayListRelDTO = UploadPlayListRel;
                    return PlayList;
                }, splitOn: "ID_UPLOAD_PLAYLIST").ToList();
            }
        }

        public IEnumerable<PlayListDTO> ObterPlayEdit(ObterPlayListParaEditRequest pObterPlayListParaEditRequest)
        {
            //Int64 a = 1;
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                return conexao.Query<PlayListDTO>(
                    "SELECT  CP.ID_PLAYLIST, CP.NM_PLAYLIST, CP.FL_PLAYLIST_ATIVO, " +
                        "CUP.ID_UPLOAD_PLAYLIST, CUP.CD_ARQUIVO_UPLOAD, CUP.NU_ORDEM_EXIBICAO, "+
                        "CAU.ID_ARQUIVO_UPLOAD, CAU.NM_ARQUIVO_UPLOAD "+
                        "FROM TB_CILHAS_PLAYLIST CP "+
                        "JOIN TB_CILHAS_UPLOAD_PLAYLIST CUP ON CP.ID_PLAYLIST = CUP.CD_PLAYLIST "+
                        "JOIN TB_CILHAS_ARQUIVO_UPLOAD CAU ON CAU.ID_ARQUIVO_UPLOAD = CUP.CD_ARQUIVO_UPLOAD "+
                        "WHERE ID_PLAYLIST = :ID_PLAYLIST ",
                   new { ID_PLAYLIST = pObterPlayListParaEditRequest.IdPlayList });
            }
        }

        public Int64 InserirPlayList(InserirPlayListRequest pInserir)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT SQ_CILHAS_PLAYLIST.NEXTVAL FROM DUAL";
                Int64 SQ = Convert.ToInt32(conexao.QueryFirstOrDefault<Int64>(sSql, null));
                //sSql = "SELECT SQ_CILHAS_UPLOAD_PLAYLIST.NEXTVAL FROM DUAL";
                //Int64 SQRel = Convert.ToInt32(conexao.QueryFirstOrDefault<Int64>(sSql, null));

                conexao.Open();
                OracleCommand command = conexao.CreateCommand();
                OracleTransaction transaction = conexao.BeginTransaction();
                try
                {
                    sSql = "INSERT INTO TB_CILHAS_PLAYLIST(ID_PLAYLIST, NM_PLAYLIST, TP_PLAYLIST, NM_CAS) values(:ID_PLAYLIST, :NM_PLAYLIST, :TP_PLAYLIST, :NM_CAS)";
                    var pTranparameters = new { ID_PLAYLIST = SQ, NM_PLAYLIST = pInserir.PlayList.NM_PLAYLIST, TP_PLAYLIST = pInserir.PlayList.TP_PLAYLIST, NM_CAS = pInserir.PlayList.NM_CAS };
                    conexao.Execute(sSql, pTranparameters, transaction);

                    var arquivosParaUpload = pInserir.PlayList.TP_PLAYLIST.Split(",");
                    
                    foreach (var aUpload in arquivosParaUpload)
                    {

                        sSql = "INSERT INTO TB_CILHAS_UPLOAD_PLAYLIST(ID_UPLOAD_PLAYLIST, CD_ARQUIVO_UPLOAD, CD_PLAYLIST) values(SQ_CILHAS_UPLOAD_PLAYLIST.NEXTVAL, :CD_ARQUIVO_UPLOAD, :CD_PLAYLIST)";
                        var sTranparameters = new { CD_ARQUIVO_UPLOAD = Convert.ToInt32(aUpload), CD_PLAYLIST = SQ };
                        conexao.Execute(sSql, sTranparameters, transaction);

                        transaction.Commit();
                    }                    

                    conexao.Close();

                    return SQ;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conexao.Close();
                    throw;
                }
            }
        }

        public Int64 ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest)
        {
                using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
                {
                    Int64 SQ = 1;

                var sSql = String.Format("DELETE FROM TB_CILHAS_UPLOAD_PLAYLIST WHERE CD_PLAYLIST = {0}", pExcluirPlayListRequest.PlayList.ID_PLAYLIST);
                var executeSql = conexao.Execute(sSql, null, commandType: CommandType.Text);

                sSql = String.Format("DELETE FROM TB_CILHAS_PLAYLIST WHERE ID_PLAYLIST = {0}", pExcluirPlayListRequest.PlayList.ID_PLAYLIST);
                executeSql = conexao.Execute(sSql, null, commandType: CommandType.Text);

                //    conexao.Open();
                //    OracleCommand command = conexao.CreateCommand();
                //    OracleTransaction transaction = conexao.BeginTransaction();
                //    try
                //    {
                //        var sSql = "DELETE FROM TB_CILHAS_UPLOAD_PLAYLIST WHERE CD_PLAYLIST = CD_PLAYLIST";
                //        var pTranparameters = new { CD_PLAYLIST = pExcluirPlayListRequest.PlayList.ID_PLAYLIST };
                //        conexao.Execute(sSql, pTranparameters, transaction);

                //        sSql = "DELETE FROM TB_CILHAS_PLAYLIST WHERE ID_PLAYLIST = ID_PLAYLIST";
                //        var sTranparameters = new { ID_PLAYLIST = pExcluirPlayListRequest.PlayList.ID_PLAYLIST };
                //        conexao.Execute(sSql, sTranparameters, transaction);

                //        transaction.Commit();
                //        conexao.Close();

                        return SQ;
                //    }
                //    catch (Exception)
                //    {
                //        transaction.Rollback();
                //        conexao.Close();
                //        throw;
                //    }
            }
            //using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            //{
            //    var sSql = String.Format("DELETE FROM TB_CILHAS_PLAYLIST WHERE ID_PLAYLIST = {0}", pExcluirPlayListRequest.PlayList.ID_PLAYLIST);
            //    return conexao.Execute(sSql, null, commandType: CommandType.Text);
            //}
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
