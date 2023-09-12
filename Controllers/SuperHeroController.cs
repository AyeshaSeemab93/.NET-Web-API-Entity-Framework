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
        private readonly ISuperHeroService _superHeroService;

        //create the constructor to inject the interface (dependency injection)
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

            ////return Ok(result);
            //return Ok(superHeroes);


            //receiving the method results from services method(where it is written properly)via dependency injection
            var result = await _superHeroService.GetAllHeroes(); 

            return Ok(result);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetsingleHero(int id)
        {//way 1
            //    var selectedhero = superHeroes.Find(x => x.Id == id);
            //    if (selectedhero is null) {
            //        return NotFound("does not exist");
            //    }
            //way 2
            //foreach (var hero in superHeroes)
            //{
            //    if (hero.Id == id)

            //        return Ok(hero);
            //}
            //return NotFound("does not exist");

            var result =await _superHeroService.GetsingleHero(id);
            if (result is null)
                return NotFound("Hero Not Found");
            return Ok(result);
        }


        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(int id, SuperHero hero)
        {
            //superHeroes.Add(hero);
            //return superHeroes;

            var result =await _superHeroService.AddHero(hero);
          
            return Ok(result);

        }


        // find superhero with the similar id of newhero.Update the name etc with new one

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero newhero)

        {
            //moved to services-class
            //var hero = superHeroes.Find(f => f.Id == newhero.Id);
            //if (hero is null)
            //{ return NotFound("hero does not exist"); }
            //else
            //    hero.Name = newhero.Name;
            //hero.FirstName = newhero.FirstName;
            //hero.LastName = newhero.LastName;

            //return Ok(superHeroes);


    //receiving from services-class through constructor and displaying it

            var result =await _superHeroService.UpdateHero(id, newhero);
            if(result is null)
            {
                return NotFound("hero does not exist");
            }
            return Ok(result);

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
            //receiving from services-class through constructor and displaying it

            var result = await _superHeroService.DeleteHero(id);
            
            if (result is null)  //all same above code 
                return NotFound("does not exist");

            return Ok(result);
        }


    }
}
