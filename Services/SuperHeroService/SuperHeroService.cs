//CLASS, INHERIT THE INTERFCAE
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {

        public static List<SuperHero> SuperHeroes = new List<SuperHero>{
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


        //inject the database now in services -Ceate constructor
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }






        //CRUD Operations:

        public async Task<List<SuperHero>?> AddHero([FromBody] SuperHero hero)
        {
            //adding hero to table
            _context.SuperHeroes.Add(hero);
            //saving in database
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync(); ;
        }

        public async Task<List<SuperHero>?> DeleteHero(int id) //? to remove green line from under null.it means list can be null
        {
            //var hero = SuperHeroes.Find(x => x.Id == id);
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                //return NotFound("does not exist"); can not return status code here so return null or empty list
                return null;
            _context.SuperHeroes.Remove(hero);
            //save changes in datbase
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync(); ;
        }



        public async Task<List<SuperHero>> GetAllHeroes()
        {
            //bringing data from database
            var heroes = await _context.SuperHeroes.ToListAsync(); //SuperHeroes = name of table in database
            return heroes;
            //bec we are returning async so add task in method(asyns added automatically)
        }


        public async Task<SuperHero?> GetsingleHero(int id)
        {

            //foreach (var hero in SuperHeroes)
            //{
            //    if (hero.Id == id)

            //        return hero;
            //}
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            return hero;
        }
    

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero newhero)
        {
            //var hero = SuperHeroes.Find(f => f.Id == newhero.Id);
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            //{ return NotFound("hero does not exist"); }
            { return null; }
            else
            {
                hero.Name = newhero.Name;
                hero.FirstName = newhero.FirstName;
                hero.LastName = newhero.LastName;

                //save changes to databases
                await _context.SaveChangesAsync();

                return await _context.SuperHeroes.ToListAsync();
            }
        }
    }
}