using Microsoft.AspNetCore.Mvc;
using PDS.Dtos;
using PDS.Models;
using System.Text.RegularExpressions;

namespace PDS.Controllers
{
    [Route("Veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        List<Veiculo> ListaVeiculos = new List<Veiculo>();

        public VeiculoController()
        {
            var carro1 = new Veiculo()
            {
                Id = 1,
                Marca = "Honda",
                Modelo = "Civic Type R",
                AnoFab = 2018,
                AnoModelo = 2019,
                Placa = "GEF-1234"
            };

            var carro2 = new Veiculo()
            {
                Id = 2,
                Marca = "Toyota",
                Modelo = "Corolla GR-S",
                AnoFab = 2018,
                AnoModelo = 2019,
                Placa = "GEG-4321"
            };

            ListaVeiculos.Add(carro1);
            ListaVeiculos.Add(carro2);
        }

        [HttpGet("{Id}")]
        public IActionResult GetByed(int Id)
        {
            var veiculo = ListaVeiculos.Where(item => item.Id == Id).FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoDTO item)
        {
            var contador = ListaVeiculos.Count();

            var veiculo = new Veiculo();

            veiculo.Id = contador + 1;
            veiculo.Marca = item.Marca;
            veiculo.Modelo = item.Modelo;
            veiculo.AnoFab = item.AnoFab;
            veiculo.AnoModelo = item.AnoModelo;
            veiculo.Placa = item.Placa;

            string padrao = "@^[A-B]{3}-d{4}$";
            Regex regex = new Regex(padrao);

            regex.IsMatch(item.Placa.ToUpper());

            if(regex.IsMatch(item.Placa.ToUpper()) == false)
            {
                return BadRequest("Placa Inválida");
            }

            if (item.AnoFab < 2000)
            {
            return BadRequest("Ano fabricação menor que anos 2000.");
            }

            if(veiculo.AnoModelo < veiculo.AnoFab)
            {
                return BadRequest("Ano Modelo menor que ano fabricação.");
            }

            ListaVeiculos.Add(veiculo);

            return StatusCode(StatusCodes.Status201Created, veiculo);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] VeiculoDTO item)
        {
            var veiculo = ListaVeiculos.Where(item => item.Id == Id).FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }

            veiculo.Marca = item.Marca;
            veiculo.Modelo = item.Modelo;
            veiculo.AnoFab = item.AnoFab;
            veiculo.AnoModelo = item.AnoModelo;
            veiculo.Placa = item.Placa;

            string padrao = "[A - Z]{ 3}[0 - 9][0 - 9A - Z][0 - 9]{ 2}";
            Regex regex = new Regex(padrao);   
                
            regex.IsMatch(item.Placa.ToUpper());

            if(regex.IsMatch(item.Placa.ToUpper()) == false)
            {
                return BadRequest("Placa Inválida");
            }

            if (item.AnoFab < 2000)
            {
                return BadRequest("Ano fabricação menor que anos 2000.");
            }

            if (veiculo.AnoModelo < veiculo.AnoFab)
            {
                return BadRequest("Ano Modelo menor que ano fabricação.");
            }

            return Ok(ListaVeiculos);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var veiculo = ListaVeiculos.Where(item => item.Id == Id).FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }

            ListaVeiculos.Remove(veiculo);

            return Ok(veiculo);
        }
    }
}
