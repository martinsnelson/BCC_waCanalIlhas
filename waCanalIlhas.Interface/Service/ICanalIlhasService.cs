﻿using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.Interface.Service
{
    public interface ICanalIlhasService
    {
        ObterListaCasResponse ObterListaCas();
        ObterCasResponse ObterCas(int pObterCasRequest);
    }
}
