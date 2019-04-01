using Dapper.Contrib.Extensions;
using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    [Table("TB_CILHAS_ARQUIVO_UPLOAD")]
    public class ArquivosDTO
    {
        [DataMember]
        [ExplicitKey]
        public int ID_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public string TP_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public string NM_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public bool FL_SELECIONADO { get; set; }
    }
}
