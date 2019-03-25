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

        public IList<UploadDTO> ObterUploads()
        {
            var lUploads = new List<UploadDTO>();
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT ID_CILHAS, NOME, TIPO, TAMANHO, CAMINHO, DT_UPLOAD, DT_EXCLUSAO, ATIVO, DURACAO, NU_MATR_UPLOAD, NU_MATR_EXCLUSAO FROM TB_CILHAS_UPLOAD";
                    var sSqlRetorno = conexao.Query<UploadDTO>(sSql).ToList();
                return sSqlRetorno;
            }
        }

        public ObterUploadResponse ObterUpload(ObterUploadRequest pObterUploadRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                var sSql = "SELECT ID_CILHAS, NOME FROM TB_CILHAS_UPLOAD WHERE NOME = :NOME";
                DynamicParameters dyParam = new DynamicParameters();
                dyParam.Add("NOME", pObterUploadRequest.NomeUpload, DbType.String, ParameterDirection.Input);
                var sSqlRetorno = conexao.QueryFirstOrDefault<ObterUploadResponse>(sSql, dyParam);

                return sSqlRetorno;
            }
        }

        //public DeletarUploadResponse DeletarArquivo(DeletarUploadRequest pDeletarUploadRequest)
        //{
        //    using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
        //    {
        //        var sSql = "DELETE FROM TB_CILHAS_UPLOAD WHERE ID_CILHAS = :ID_CILHAS";
        //        DynamicParameters dyParam = new DynamicParameters();
        //        dyParam.Add("ID_CILHAS", pDeletarUploadRequest.Upload.Id, DbType.String, ParameterDirection.Input);
        //        var sSqlRetorno = conexao.QueryFirstOrDefault<DeletarUploadResponse>(sSql, dyParam);

        //        return sSqlRetorno;
        //    }
        //}

        public Int64 SalvarUpload(SavarUploadRequest pUploadSavarRequest)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("DESENV")))
            {
                #region
                //    //return conexao.GetAll<UploadDTO>();
                //    {
                //        var parametros = new DynamicParameters();
                //        parametros.Add("@NomeProduto", nomeProduto);
                //        parametros.Add("@Preco", preco);
                //        parametros.Add("@IdProduto",
                //            dbType: DbType.Int32,
                //            direction: ParameterDirection.Output);

                //        conexao.Execute("dbo.PRC_INS_PRODUTO", parametros,
                //            commandType: CommandType.StoredProcedure);

                //        //Console.WriteLine(
                //        //    $"Cadastro o Produto { parametros.Get<int>("@IdProduto") }");
                //    }
                #endregion
                var sSql = "SELECT SQ_CILHAS_UPLOAD.NEXTVAL FROM DUAL";
                Int64 SQ = conexao.QueryFirstOrDefault<Int64>(sSql, null);

                sSql = @"INSERT INTO TB_CILHAS_UPLOAD
                                            (ID_CILHAS
                                             ,NOME
                                             ,TIPO
                                             ,TAMANHO
                                             ,CAMINHO
                                             ,DT_UPLOAD
                                             --,DT_EXCLUSAO
                                             --,ATIVO
                                             --,DURACAO
                                             --,NU_MATR_UPLOAD
                                             --,NU_MATR_EXCLUSAO
                                            )
                                            VALUES
                                            (:ID_CILHAS,
                                             :NOME,
                                             :TIPO,
                                             :TAMANHO,
                                             :CAMINHO,
                                             :DT_UPLOAD
                                             --:DT_EXCLUSAO
                                             --:ATIVO
                                             --:DURACAO
                                             --:NU_MATR_UPLOAD
                                             --:NU_MATR_EXCLUSAO
                                            )";

                DynamicParameters dyParam = new DynamicParameters();

                dyParam.Add("ID_CILHAS", SQ, DbType.Int64, ParameterDirection.Input);
                dyParam.Add("NOME", pUploadSavarRequest.Upload.Nome, DbType.String, ParameterDirection.Input);
                dyParam.Add("TIPO", pUploadSavarRequest.Upload.Tipo, DbType.String, ParameterDirection.Input);
                dyParam.Add("TAMANHO", pUploadSavarRequest.Upload.Tamanho, DbType.Int64, ParameterDirection.Input);
                dyParam.Add("CAMINHO", pUploadSavarRequest.Upload.Caminho, DbType.String, ParameterDirection.Input);
                dyParam.Add("DT_UPLOAD", pUploadSavarRequest.Upload.DataUpload, DbType.String, ParameterDirection.Input);
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