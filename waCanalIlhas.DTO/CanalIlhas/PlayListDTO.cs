using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    [Table("TB_CILHAS_PLAYLIST")]
    public class PlayListDTO
    {
        [DataMember]
        [ExplicitKey]
        public int ID_PLAYLIST { get; set; }

        [DataMember]
        public string NM_PLAYLIST { get; set; }

        [DataMember]
        public string TP_PLAYLIST { get; set; }

        [DataMember]
        public string NM_CAS { get; set; }

        [DataMember]
        public int? NU_ORDEM_EXIBICAO { get; set; }

        [DataMember]
        public long? DS_TAMANHO_PLAYLIST { get; set; }

        [DataMember]
        public string NM_CAMINHO_PLAYLIST { get; set; }

        [DataMember]
        public string DT_CRIACAO_PLAYLIST { get; set; }

        [DataMember]
        public string DT_EXCLUSAO_PLAYLIST { get; set; }

        [DataMember]
        public byte? FL_PLAYLIST_ATIVO { get; set; }

        [DataMember]
        public string DS_DURACAO_PLAYLIST { get; set; }

        [DataMember]
        public int? NU_MATR_CRIACAO { get; set; }

        [DataMember]
        public int? NU_MATR_EXCLUSAO { get; set; }

        public UploadPlayListRelDTO UploadPlayListRelDTO { get; set; }
    }
}
