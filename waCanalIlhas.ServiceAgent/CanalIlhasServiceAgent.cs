using System;
using System.Collections.Generic;
using System.Text;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.ServiceAgent
{
    public class CanalIlhasServiceAgent
    {
        
        public ObterCasResponse ObterListaCas()
        {
            return Http.Get<ObterCasResponse>("v1/api/CanalIlhas/ObterListaCas");
        }
    }
}
