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



        public List<SuperHero> AddHero([FromBody] SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero>? DeleteHero(int id) //? to remove green line from under null.it means list can be null
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                //return NotFound("does not exist"); can not return status code here so return null or empty list
                return null;
            superHeroes.Remove(hero);
            return superHeroes;
        }



        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }


        public SuperHero? GetsingleHero(int id)
        {

            foreach (var hero in superHeroes)
            {
                if (hero.Id == id)

                    return hero;
            }
            //return NotFound("does not exist");
            return null;
        }

        public List<SuperHero>? UpdateHero(SuperHero newhero)
        {
            var hero = superHeroes.Find(f => f.Id == newhero.Id);
            if (hero is null)
            //{ return NotFound("hero does not exist"); }
            { return null; }
            else
            {
                hero.Name = newhero.Name;
                hero.FirstName = newhero.FirstName;
                hero.LastName = newhero.LastName;

                return superHeroes;
            }
        }

    }
}

