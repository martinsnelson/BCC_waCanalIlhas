using System;
using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.Upload
{
    [DataContract]
    public class UploadDTO
    {
        [DataMember]
        public long Id { get; set; }

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
        public bool Ativo { get; set; }

        [DataMember]
        public long Tempo { get; set; }

        [DataMember]
        public int MatriculaUpload { get; set; }

        [DataMember]
        public int MatriculaExclusao { get; set; }
    }
}
