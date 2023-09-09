//CLASS, INHERIT THE INTERFCAE
using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {

        public static List<SuperHero> superHeroes = new List<SuperHero>{
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                address = "New York City"

             }
            ,
            new SuperHero{
                Id = 2,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                address = "New York City"

               },
            new SuperHero{
                Id = 3,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                address = "New York City"

               }
        };



        public IEnumerable<SuperHero> AddHero([FromBody] SuperHero hero)
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                //return NotFound("does not exist"); can not return status code here so return null or empty list
                return null;
            superHeroes.Remove(hero);
            return superHeroes;
        }

        public IEnumerable<SuperHero> Get()
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetHeroes()
        {
            throw new NotImplementedException();
        }

        public SuperHero GetsingleHero(int id)
        {
            throw new NotImplementedException();
        }

        public SuperHero UpdateHero(SuperHero newhero)
        {
            throw new NotImplementedException();
        }
    }
}

