using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoronaVirus.Api.Data.Collections;
using CoronaVirus.Api.Models;
using CoronaVirus.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoronaVirus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectadosController : ControllerBase
    {
        private readonly IInfectadoService _infectadoService;
        private readonly IMapper _mapper;

        public InfectadosController(IInfectadoService infectadoService,
                                    IMapper mapper)
        {
            _infectadoService = infectadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<InfectadoDTO>> Get() =>
            _mapper.Map<List<InfectadoDTO>>(_infectadoService.Get());

        [HttpGet("{id:length(24)}", Name = "GetInfectadol")]
        public ActionResult<InfectadoDTO> Get(string id)
        {
            var infectado = _mapper.Map<InfectadoDTO>(_infectadoService.Get(id));

            if (infectado == null)
            {
                return NotFound();
            }

            return infectado;
        }

        [HttpPost]
        public ActionResult<InfectadoDTO> Create(InfectadoDTO infectadoDTO)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(e => e.Errors);
                return BadRequest(erros);
            }

            Infectado infectado = _infectadoService.Create(_mapper.Map<Infectado>(infectadoDTO));

            return Created("GetInfectado", infectado);
        }

        // [HttpPut("{id:length(24)}")]
        // public IActionResult Update(string id, Infectado infectado)
        // {
        //     var infectadoAux = _infectadoService.Get(id);

        //     if (infectadoAux == null)
        //     {
        //         return NotFound();
        //     }

        //     _infectadoService.Update(id, infectado);

        //     return NoContent();
        // }

        // [HttpDelete("{id:length(24)}")]
        // public IActionResult Delete(string id)
        // {
        //     var infectado = _infectadoService.Get(id);

        //     if (infectado == null)
        //     {
        //         return NotFound();
        //     }

        //     _infectadoService.Remove(infectado.Id);

        //     return NoContent();
        // }
    }
}