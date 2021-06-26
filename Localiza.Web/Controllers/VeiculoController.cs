using Localiza.Dominio.Contratos;
using Localiza.Dominio.Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Localiza.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public VeiculoController(IVeiculoRepositorio veiculoRepositorio,
            IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _veiculoRepositorio = veiculoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_veiculoRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }

        [HttpPost]

        public IActionResult Post([FromBody] Veiculo veiculo) // frombody -  transforma o q veio pelo corpo da requisição em um objeto que é conhecido pelo sistema
        {
            try
            {

                veiculo.Validate();
                if (!veiculo.EhValido)
                {
                    return BadRequest(veiculo.ObterMensagemValidacao());
                }

                if (veiculo.Id > 0)
                {
                    _veiculoRepositorio.Atualizar(veiculo); //aqui chama o Atualizar o veiculo que já foi carregado na mesma template do cadastro.
                }
                else
                {
                    _veiculoRepositorio.Adicionar(veiculo); // aqui chama o cadastrar usando o template de cadastro
                }

                return Created("api/veiculo", veiculo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Veiculo veiculo)
        {
            try
            {
                // Veiculo recebido pelo [FromBody], deve ter Id > 0

                _veiculoRepositorio.Remover(veiculo);
                return Json(_veiculoRepositorio.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }

        }

        [HttpPost("EnviarArquivo")]

        public IActionResult EnviarArquivo()
        {
            try
            {


                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);

                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;



                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }
                return Json(novoNomeArquivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }

        }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-") + "." + extensao;
            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
            return novoNomeArquivo;
        }

    }
}
