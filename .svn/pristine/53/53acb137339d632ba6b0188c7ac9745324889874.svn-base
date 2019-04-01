using Dapper.Contrib.Extensions;
using System;
using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Upload
{
    [DataContract]
    [Table("TB_CILHAS_ARQUIVO_UPLOAD")]
    public class UploadDTO
    {
        [DataMember]
        [ExplicitKey]
        public int ID_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public string NM_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public string TP_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public long? DS_TAMANHO_ARQUIVO { get; set; }

        [DataMember]
        public string NM_CAMINHO_ARQUIVO { get; set; }

        [DataMember]
        public string DT_UPLOAD_ARQUIVO { get; set; }

        [DataMember]
        public string DT_EXCLUSAO_ARQUIVO { get; set; }

        [DataMember]
        public byte? FL_ARQUIVO_ATIVO { get; set; }

        [DataMember]
        public long? DS_DURACAO_ARQUIVO { get; set; }

        [DataMember]
        public int? NU_MATR_UPLOAD { get; set; }

        [DataMember]
        public int? NU_MATR_EXCLUSAO { get; set; }
    }
}
