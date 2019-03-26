using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace waCanalIlhas.DTO.CanalIlhas
{
    [DataContract]
    public class CasDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }
    }
}
