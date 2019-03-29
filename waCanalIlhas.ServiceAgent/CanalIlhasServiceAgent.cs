using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.ServiceAgent
{
    public class CanalIlhasServiceAgent
    {

        public ObterListaCasResponse ObterListaCas()
        {
            return Http.Get<ObterListaCasResponse>("v1/api/CanalIlhas/ObterListaCas");
        }

        public ObterCasResponse ObterCas(ObterCasRequest pObterCasRequest)
        {
            return Http.Getp<ObterCasResponse>("v1/api/CanalIlhas/ObterCas", pObterCasRequest);
        }

        public ListaArquivosResponse ListaVideos()
        {
            return Http.Get<ListaArquivosResponse>("v1/api/CanalIlhas/ListaVideos");
        }

        public ListaArquivosResponse ListaImagens()
        {
            return Http.Get<ListaArquivosResponse>("v1/api/CanalIlhas/ListaImagens");
        }

        public ObterPlayListResponse ObterPlayList()
        {
            return Http.Get<ObterPlayListResponse>("v1/api/CanalIlhas/ObterPlayList");
        }

        public InserirPlayListResponse InserirPlayList(InserirPlayListRequest pInserirPlayListRequest)
        {
            return Http.Post<InserirPlayListResponse>("v1/api/CanalIlhas/InserirPlayList", pInserirPlayListRequest);
        }
    }
}
