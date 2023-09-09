//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//BASIC CONTROLLER WITH CRUD OPERATIONS

//namespace SuperHeroApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SuperHeroController : ControllerBase
//    {
//        public static List<SuperHero> superHeroes = new List<SuperHero>{
//            new SuperHero
//            {
//                Id = 1,
//                Name = "Spider Man",
//                FirstName = "Peter",
//                LastName = "Parker",
//                address = "New York City"

//             }
//            ,
//            new SuperHero{
//                Id = 2,
//                Name = "Spider Man",
//                FirstName = "Peter",
//                LastName = "Parker",
//                address = "New York City"

//               },
//            new SuperHero{
//                Id = 3,
//                Name = "Spider Man",
//                FirstName = "Peter",
//                LastName = "Parker",
//                address = "New York City"

//               }
//        };
//        //way 1   <List<SuperHero>> added to show schema on the swagger
//        [HttpGet]
//        public async Task <ActionResult<List<SuperHero>>> GetAllHeroes()
//        {
//            //var result = new List<SuperHero>
//            //{
//            //    new SuperHero
//            //    {
//            //        Id = 1,
//            //        Name = "Spider Man",
//            //        FirstName = "Peter",
//            //        LastName = "Parker",
//            //        address = "New York City" }
//            //    };

//            //return Ok(result);
//            return superHeroes;
//        }

//        //way 2
//        [HttpGet("2")]
//        public IActionResult GetHeroes()
//        {
//            //var result = new List<SuperHero>
//            //{
//            //    new SuperHero
//            //    {
//            //        Id = 1,
//            //        Name = "Spider Man",
//            //        FirstName = "Peter",
//            //        LastName = "Parker",
//            //        address = "New York City" }
//            //};

//            //return Ok(result);
//            return Ok(superHeroes);
//        }


//        //way 3
//        [HttpGet("3")]
//        public async Task<IEnumerable<SuperHero>> Get()

//        {
      
//            return superHeroes;
//        }


//        [HttpGet("{id}")]
//        public async Task<ActionResult<SuperHero>> GetsingleHero(int id)
//        {
//            //    var selectedhero = superHeroes.Find(x => x.Id == id);
//            //    if (selectedhero is null) {
//            //        return NotFound("does not exist");
//            //    }
        
//            foreach (var hero in superHeroes)
//            {
//                if (hero.Id == id)
                
//                    return Ok(hero);       
//            }
//            return NotFound("does not exist");
//        }


//        [HttpPost]

//       public async Task<IEnumerable<SuperHero>> AddHero([FromBody]SuperHero hero)
//        {
//            superHeroes.Add(hero);
//            return superHeroes;
//        }


//        // find superhero with the similar id of newhero.Update the name etc with new one

//        [HttpPut]
//        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero newhero)

//        {
//           //way 1 to go through the list using foreach


//            //foreach(var hero in superHeroes)
//            //    {
//            //        if (hero.Id == newhero.Id)
//            //        {
//            //            hero.Name = newhero.Name;
//            //            hero.FirstName = newhero.FirstName;
//            //            hero.LastName = newhero.LastName;

//            //        }
//            //}

//            //way 2 to go through list
//            var hero = superHeroes.Find(f => f.Id == newhero.Id);
//             if(hero is null)
//            { return NotFound("hero does not exist"); }
//             else
//                hero.Name = newhero.Name;
//                hero.FirstName = newhero.FirstName;
//                hero.LastName = newhero.LastName;

//            return Ok(superHeroes);
//        }
//        [HttpDelete]
//        public async Task <ActionResult<List<SuperHero>>> DeleteHero(int id)
//        {
//            var hero = superHeroes.Find(x => x.Id == id);
//            if (hero is null)
//                return NotFound("does not exist");
//            superHeroes.Remove(hero);
//            return superHeroes;

//        }
  

//    }
//}
