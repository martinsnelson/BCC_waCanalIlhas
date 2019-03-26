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
        public long NU_TAMANHO_ARQUIVO { get; set; }

        [DataMember]
        public string NM_CAMINHO_ARQUIVO { get; set; }

        /*
        [DataMember]
        [ExplicitKey]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public long Tamanho { get; set; }

        [DataMember]
        public string Caminho { get; set; }

        [DataMember]
        public DateTime DataUpload { get; set; }

        [DataMember]
        public DateTime DataExclusao { get; set; }

        [DataMember]
        public char? Ativo { get; set; }

        [DataMember]
        public long? Duracao { get; set; }

        [DataMember]
        public int? MatriculaUpload { get; set; }

        [DataMember]
        public int? MatriculaExclusao { get; set; }
        */
    }
}
