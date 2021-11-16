using Capa_AgendaRepository1;
using Capa_ModeloEntidades1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApiExamenBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaRepository agendaRepository;

        public AgendaController()
        {
            agendaRepository = new AgendaRepository();
        }

        [HttpGet]
        public IEnumerable<Agenda> Get()
        {
            return agendaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Agenda Get(Guid id)
        {
            return agendaRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Agenda Age)
        {
            if (ModelState.IsValid)
            {
                agendaRepository.Add(Age);
            }            
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Agenda Age)
        {
            Age.Id  = id;
            if (ModelState.IsValid)
            {
                agendaRepository.Update(Age);
            }
        }

        [HttpDelete]
        public void DeletePut(Guid id)
        {         

            if (ModelState.IsValid)
            {
                agendaRepository.Delete(id);
            }
        }

    }
}
