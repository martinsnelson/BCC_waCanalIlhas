using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace waCanalIlhas.Results
{
    /*
     * class EmpurrarCorrenteResultado
     * será responsável por obter o stream, setar o content type e 
     * retornar para um callback onde vamos identificar quem receberá os conteúdos.
     */
    public class EmpurrarCorrenteResultado : IActionResult
    {
        private readonly Action<Stream, CancellationToken> _emCorrenteAcessivel;
        private readonly string _tipoConteudo;
        private readonly CancellationToken _pedidoAbortado;

        public EmpurrarCorrenteResultado(Action<Stream, CancellationToken> emCorrenteAcessivel, string tipoConteudo, CancellationToken pedidoAbortado)
        {
            _emCorrenteAcessivel = emCorrenteAcessivel;
            _tipoConteudo = tipoConteudo;
            _pedidoAbortado = pedidoAbortado;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var stream = context.HttpContext.Response.Body;
            //context.HttpContext.Response.GetTypedHeaders().ContentType = new MediaTypeHeaderValue(_tipoConteudo);
            _emCorrenteAcessivel(stream, _pedidoAbortado);
            return Task.CompletedTask;
        }
    }
}
