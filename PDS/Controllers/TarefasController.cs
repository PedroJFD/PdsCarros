using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDS.Models;
using PDS.Dtos;

namespace PDS.Controllers
{
    [Route("Tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        List<Tarefa> ListaTarefas = new List<Tarefa>();

        public TarefasController()
        {
            var tarefa1 = new Tarefa()
            {
                Id = 1,
                Descricao = "Estudo de API part 1",
                Feito = false
            };
            var tarefa2 = new Tarefa()
            {
                Id = 2,
                Descricao = "Estudo de API part 2",
                Feito = false
            };
            var tarefa3 = new Tarefa()
            {
                Id = 3,
                Descricao = "Estudo de API part 3",
                Feito = false
            };
            ListaTarefas.Add(tarefa1);
            ListaTarefas.Add(tarefa2);
            ListaTarefas.Add(tarefa3);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ListaTarefas);
        }
        [HttpGet("{Id}")]
        public IActionResult GetByed(int Id) {
            var tarefa = ListaTarefas.Where(item => item.Id == Id).FirstOrDefault();

            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarefa item)
        {
            var contador = ListaTarefas.Count();

            var tarefa = new Tarefa();

            tarefa.Id = contador + 1;
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            ListaTarefas.Add(tarefa);

            return StatusCode(StatusCodes.Status201Created, tarefa);
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] TarefaDTO item) 
        {
            var tarefa = ListaTarefas.Where(item => item.Id == Id).FirstOrDefault();

            if(tarefa == null)
            {
                return NotFound();
            }

            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            return Ok(ListaTarefas);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id) 
        {
            var tarefa = ListaTarefas.Where(item => item.Id == Id).FirstOrDefault();

            if (tarefa == null)
            {
                return NotFound();
            }

            ListaTarefas.Remove(tarefa);

            return Ok(tarefa);
        }
    }
}
