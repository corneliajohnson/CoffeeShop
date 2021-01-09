﻿using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepo;
        public CoffeeController (ICoffeeRepository coffeeRepo)
        {
            _coffeeRepo = coffeeRepo;
        }

        // https://localhost:5001/api/coffee/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coffeeRepo.GetAll());
        }

        // https://localhost:5001/api/coffee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variety = _coffeeRepo.Get(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }

        // https://localhost:5001/api/coffee/
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepo.Add(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }

        // https://localhost:5001/api/coffee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }

            _coffeeRepo.Update(coffee);
            return NoContent();
        }

        // https://localhost:5001/api/coffee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepo.Delete(id);
            return NoContent();
        }
    }
}
