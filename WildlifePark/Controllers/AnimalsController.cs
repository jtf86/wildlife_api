using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildlifePark.Models;

namespace WildlifePark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private WildlifeParkContext db = new WildlifeParkContext();
        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return db.Animals.ToList();
        }
        // GET api/animals/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return db.Animals.FirstOrDefault(x => x.AnimalId == id);
        }
        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
        }
        // PUT api/animals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
        }
        // DELETE api/animals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = db.Animals.FirstOrDefault(x => x.AnimalId == id);
            db.Animals.Remove(animalToDelete);
            db.SaveChanges();
        }
    }
}
