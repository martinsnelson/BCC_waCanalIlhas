using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
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

        public bool SalvarUpload(UploadSavarRequest UploadSavarRequestp)
        {
            //using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("PROD")))
            //{
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
            //}
        }
    }
}
