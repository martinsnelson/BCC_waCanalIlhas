using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using waCanalIlhas.DTO.Request.Upload;
using waCanalIlhas.DTO.Response.Upload;
using waCanalIlhas.DTO.Upload;
using waCanalIlhas.Interface.DAL;

namespace waCanalIlhas.DAL
{
    public class UploadDAL : IUploadDAL
    {
        private readonly IConfiguration _configuration;

        public UploadDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public List<UploadDTO> ObterUploads()
        //{
        //    //var lUploads = new List<UploadDTO>();
        //    using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
        //    {
        //        var sSql = "SELECT ID_ARQUIVO_UPLOAD,NM_ARQUIVO_UPLOAD,TP_ARQUIVO_UPLOAD,NU_TAMANHO_ARQUIVO FROM TB_CILHAS_ARQUIVO_UPLOAD";
        //            var sSqlRetorno = conexao.Query<UploadDTO>(sSql).ToList();
        //        return sSqlRetorno;
        //    }
        //}

        public IEnumerable<UploadDTO> ObterUploads()
        {
            //var lUploads = new List<UploadDTO>();
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var t = conexao.GetAll<UploadDTO>();
                return t;
            }
        }

        public ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT ID_ARQUIVO_UPLOAD, NM_ARQUIVO_UPLOAD FROM TB_CILHAS_ARQUIVO_UPLOAD WHERE NM_ARQUIVO_UPLOAD = :NM_ARQUIVO_UPLOAD";
                DynamicParameters dyParam = new DynamicParameters();
                dyParam.Add("NM_ARQUIVO_UPLOAD", pObterUploadRequest.NomeUpload, DbType.String, ParameterDirection.Input);
                var sSqlRetorno = conexao.QueryFirstOrDefault<ObterUploadResponse>(sSql, dyParam);

                return sSqlRetorno;
            }
        }

        public Int64 DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "DELETE FROM TB_CILHAS_ARQUIVO_UPLOAD WHERE NM_ARQUIVO_UPLOAD = ";
                var sSqlExecute = String.Format("{0}'{1}'", sSql, pDeletarUploadRequest.Upload.NM_ARQUIVO_UPLOAD);
                return conexao.Execute(sSqlExecute, null, commandType: CommandType.Text);
            }
        }

        public Int64 SalvarUpload(SavarUploadRequest pUploadSavarRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT SQ_CILHAS_ARQUIVO_UPLOAD.NEXTVAL FROM DUAL";
                Int64 SQ = conexao.QueryFirstOrDefault<Int64>(sSql, null);
                sSql = @"INSERT INTO TB_CILHAS_ARQUIVO_UPLOAD (
                                                ID_ARQUIVO_UPLOAD
                                                ,NM_ARQUIVO_UPLOAD
                                                ,TP_ARQUIVO_UPLOAD
                                                ,NU_TAMANHO_ARQUIVO
                                                ,NM_CAMINHO_ARQUIVO
                                                --,DT_UPLOAD_ARQUIVO
                                                --,DT_EXCLUSAO_ARQUIVO
                                                --,FL_ARQUIVO_ATIVO
                                                --,DS_DURACAO_ARQUIVO
                                                --,NU_MATR_UPLOAD,
                                                --NU_MATR_EXCLUSAO
                                                )
                                            VALUES(
                                                :ID_ARQUIVO_UPLOAD
                                                ,:NM_ARQUIVO_UPLOAD
                                                ,:TP_ARQUIVO_UPLOAD
                                                ,:NU_TAMANHO_ARQUIVO
                                                ,:NM_CAMINHO_ARQUIVO
                                                --,:DT_UPLOAD_ARQUIVO
                                                --,:DT_EXCLUSAO_ARQUIVO
                                                --,:FL_ARQUIVO_ATIVO
                                                --,:DS_DURACAO_ARQUIVO
                                                --,:NU_MATR_UPLOAD
                                                --:NU_MATR_EXCLUSAO
                                                )";
                DynamicParameters dyParam = new DynamicParameters();
                dyParam.Add("ID_ARQUIVO_UPLOAD", SQ, DbType.Int64, ParameterDirection.Input);
                dyParam.Add("NM_ARQUIVO_UPLOAD", pUploadSavarRequest.Upload.NM_ARQUIVO_UPLOAD, DbType.String, ParameterDirection.Input);
                dyParam.Add("TP_ARQUIVO_UPLOAD", pUploadSavarRequest.Upload.TP_ARQUIVO_UPLOAD, DbType.String, ParameterDirection.Input);
                dyParam.Add("NU_TAMANHO_ARQUIVO", pUploadSavarRequest.Upload.NU_TAMANHO_ARQUIVO, DbType.Int64, ParameterDirection.Input);
                dyParam.Add("NM_CAMINHO_ARQUIVO", pUploadSavarRequest.Upload.NU_TAMANHO_ARQUIVO, DbType.String, ParameterDirection.Input);
                //dyParam.Add("DT_UPLOAD_ARQUIVO", pUploadSavarRequest.Upload.DataUpload, DbType.DateTime, ParameterDirection.Input);
 
                //dyParam.Add("DT_EXCLUSAO", pUploadSavarRequest.Upload.DataExclusao, DbType.String, ParameterDirection.Input);
                //dyParam.Add("ATIVO", pUploadSavarRequest.Upload.Ativo, DbType.String, ParameterDirection.Input);
                //dyParam.Add("DURACAO", pUploadSavarRequest.Upload.Duracao, DbType.Int64, ParameterDirection.Input);
                //dyParam.Add("NU_MATR_UPLOAD", pUploadSavarRequest.Upload.MatriculaUpload, DbType.Int64, ParameterDirection.Input);
                //dyParam.Add("NU_MATR_EXCLUSAO", pUploadSavarRequest.Upload.MatriculaExclusao, DbType.Int64, ParameterDirection.Input);
                //dyParam.Add("ATIVO", pUploadSavarRequest.Upload.Ativo, DbType.Byte == true ? '1' : '0', ParameterDirection.Input);
       
                conexao.Execute(sSql, dyParam, commandType: CommandType.Text);
                return SQ;
            }
        }
    }
}