using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using waCanalIlhas.DTO.CanalIlhas;
using waCanalIlhas.Enums;
using waCanalIlhas.Results;

namespace waCanalIlhas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static ConcurrentBag<StreamWriter> _clientes;

        static ClienteController()
        {
            _clientes = new ConcurrentBag<StreamWriter>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO cliente)
        {
            //Fazer o Insert
            await EnviarEvento(cliente, EEventoEnum.Insert);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClienteDTO cliente)
        {
            //Fazer o Update
            await EnviarEvento(cliente, EEventoEnum.Update);
            return Ok();
        }
        private static async Task EnviarEvento(object dados, EEventoEnum evento)
        {
            foreach (var client in _clientes)
            {
                string jsonEvento = string.Format("{0}\n", JsonConvert.SerializeObject(new { dados, evento }));
                await client.WriteAsync(jsonEvento);
                await client.FlushAsync();
            }
        }

        [HttpGet]
        [Route("Streaming")]
        public IActionResult Stream()
        {
            return new EmpurrarCorrenteResultado(emCorrenteAcessivel, "text/event-stream", HttpContext.RequestAborted);
        }

        private void emCorrenteAcessivel(Stream stream, CancellationToken pedidoAbortado)
        {
            var wait = pedidoAbortado.WaitHandle;
            var client = new StreamWriter(stream);
            _clientes.Add(client);

            wait.WaitOne();

            StreamWriter ignore;
            _clientes.TryTake(out ignore);
        }
    }
}