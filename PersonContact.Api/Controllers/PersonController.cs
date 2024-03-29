﻿using Microsoft.AspNetCore.Mvc;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Context;
using PersonContact.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        private readonly PersonContactDbContext _context;
        public PersonController(IPersonRepository personRepository , PersonContactDbContext context)
        {
            _personRepository = personRepository;
            _context = context;
        }


        //Sistemde kayıtlı olan büyün kişiler getirilir.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPerson()
        {
            return await _personRepository.GetAllPerson();
        }


        //Sistemde bulunan 1 kişi getirmek için Route üzerinden ıd parametresi alınır.
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson([FromRoute] Guid id)
        {
            return await _personRepository.GetPerson(id);
        }

        //Kişi ekleyebilmek için yazılmıştır.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody] Person person) //Rehbere kişi eklemek için yazılmıştır.
        {
            _personRepository.AddPerson(person); //repository'de tanımlamış olduğum metot çalışmaktadır. 
            await _personRepository.SaveChanges(); 

            return CreatedAtAction("GetPerson", new { personId = person.Id }, person);
        }

        //Kişi ait id parametresi ile veritabanından o kişinin silinmesi işlemi
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson([FromRoute] Guid id)
        {
            _personRepository.DeletePerson(id);
            await _personRepository.SaveChanges();

            return Ok(); 
        }


    }
}
