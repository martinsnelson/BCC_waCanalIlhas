using Dapper.Contrib.Extensions;
using System.Runtime.Serialization;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    [Table("TB_CILHAS_UPLOAD_PLAYLIST")]
    public class UploadPlayListRelDTO
    {
        [DataMember]
        [ExplicitKey]
        public int? ID_UPLOAD_PLAYLIST { get; set; }

        [DataMember]
        public int? CD_ARQUIVO_UPLOAD { get; set; }

        [DataMember]
        public int? CD_PLAYLIST { get; set; }

        [DataMember]
        public int? NU_ORDEM_EXIBICAO { get; set; }
    }
}
