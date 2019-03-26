using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    public class CanalIlhasDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public long? IdCas { get; set; }

        [DataMember]
        public string Cas { get; set; }

        [DataMember]
        public int? Ordem { get; set; }

        [DataMember]
        public long? Tamanho { get; set; }

        [DataMember]
        public string Caminho { get; set; }

        [DataMember]
        public string DataCriacao { get; set; }

        [DataMember]
        public string DataExclusao { get; set; }

        [DataMember]
        public string Ativo { get; set; }

        [DataMember]
        public long? Duracao { get; set; }

        [DataMember]
        public int? NuMatrCriacao { get; set; }

        [DataMember]
        public int? NuMatrExclusao { get; set; }
    }
}
