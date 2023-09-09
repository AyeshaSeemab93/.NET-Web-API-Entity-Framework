using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        //create the constructor to inject the interface
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            //click --create & assign field
            _superHeroService = superHeroService;
        }





        //way 1   <List<SuperHero>> added to show schema on the swagger
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            //var result = new List<SuperHero>
            //{
            //    new SuperHero
            //    {
            //        Id = 1,
            //        Name = "Spider Man",
            //        FirstName = "Peter",
            //        LastName = "Parker",
            //        address = "New York City" }
            //    };

            //return Ok(result);
            return superHeroes;
        }

        //way 2
        [HttpGet("2")]
        public IActionResult GetHeroes()
        {
            //var result = new List<SuperHero>
            //{
            //    new SuperHero
            //    {
            //        Id = 1,
            //        Name = "Spider Man",
            //        FirstName = "Peter",
            //        LastName = "Parker",
            //        address = "New York City" }
            //};

            //return Ok(result);
            return Ok(superHeroes);
        }


        //way 3
        [HttpGet("3")]
        public async Task<IEnumerable<SuperHero>> Get()

        {

            return superHeroes;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetsingleHero(int id)
        {
            //    var selectedhero = superHeroes.Find(x => x.Id == id);
            //    if (selectedhero is null) {
            //        return NotFound("does not exist");
            //    }

            foreach (var hero in superHeroes)
            {
                if (hero.Id == id)

                    return Ok(hero);
            }
            return NotFound("does not exist");
        }


        [HttpPost]

        public async Task<IEnumerable<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }


        // find superhero with the similar id of newhero.Update the name etc with new one

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero newhero)

        {
            //way 1 to go through the list using foreach


            //foreach(var hero in superHeroes)
            //    {
            //        if (hero.Id == newhero.Id)
            //        {
            //            hero.Name = newhero.Name;
            //            hero.FirstName = newhero.FirstName;
            //            hero.LastName = newhero.LastName;

            //        }
            //}

            //way 2 to go through list

            var hero = superHeroes.Find(f => f.Id == newhero.Id);
            if (hero is null)
            { return NotFound("hero does not exist"); }
            else
                hero.Name = newhero.Name;
            hero.FirstName = newhero.FirstName;
            hero.LastName = newhero.LastName;

            return Ok(superHeroes);
        }
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            //MOVE THIS CODE TO Services-Class(modified there)
            //var hero = superHeroes.Find(x => x.Id == id);
            //if (hero is null)
            //    return NotFound("does not exist");
            //superHeroes.Remove(hero);
            //return superHeroes;

            //Now lets brings services to use(through contructor):

            Version result = _superHeroService.DeleteHero(id);
            
            if (result is null)  //all same above code 
                return NotFound("does not exist");

            return Ok(result);
        }


    }
}
