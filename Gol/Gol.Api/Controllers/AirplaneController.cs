using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gol.Api.Dto;
using Gol.Aplicacao.Interfaces;
using Gol.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gol.Api.Controllers
{    
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AirplaneController(IMapper mapper)
        {
            _mapper = mapper;
        }       

        // GET: api/Airplane
        [Route("v1/airplane")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneDTO>>> Get([FromServices] IAirplaneAppServico app)
        {
            return Ok(_mapper.Map<IEnumerable<Airplane>>(await app.GetAsync()));
        }

        // GET: api/Airplane/5
        [Route("v1/airplane/{id}")]
        [HttpGet]
        public async Task<ActionResult<AirplaneDTO>> Get([FromServices] IAirplaneAppServico app, int id)
        {
            var result = _mapper.Map<Airplane>(app.First(x => x.Id == id));

            if (result == null)
            {
                return NotFound();
            }

            return  Ok(result);
        }

        // PUT: api/Airplane/5
        //[ClaimsAuthorize("Airplane", "Editar")]
        [Route("v1/airplane")]
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IAirplaneAppServico app, AirplaneDTO airplaneDTO)
        {
            if (airplaneDTO == null)
            {
                return BadRequest();
            }

            try
            {
                app.Update(_mapper.Map <Airplane>(airplaneDTO));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!app.Exists(x => x.Id == airplaneDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Airplane atualiza com sucesso");
        }

        //[ClaimsAuthorize("Airplane", "Incluir")]
        [Route("v1/airplane")]
        [HttpPost]
        public async Task<ActionResult<Airplane>> Post([FromServices] IAirplaneAppServico app, AirplaneDTO airplaneDTO)
        {
            await app.InsertAsync(_mapper.Map<Airplane>(airplaneDTO));

            return CreatedAtAction("Get", new { id = airplaneDTO.Id }, airplaneDTO);
        }

        //[ClaimsAuthorize("Airplane", "Excluir")]
        [Route("v1/airplane/{id}")]
        [HttpDelete]
        public async Task<ActionResult<AirplaneDTO>> Delete([FromServices] IAirplaneAppServico app, int id)
        {
            var airplane = await app.GetAsync();
            if (airplane == null)
            {
                return NotFound();
            }

            app.Delete(x => x.Id == id);

            return Ok(airplane);
        }

        private bool AirplaneExists([FromServices] IAirplaneAppServico app, int id)
        {
            return app.Exists(x => x.Id == id);
        }
    }
}