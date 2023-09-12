//			Interface

using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
	public interface ISuperHeroService
    {

        //copy paste (method names + return type) from controller here in interface
       Task<List<SuperHero>> GetAllHeroes();

        Task<SuperHero?> GetsingleHero(int id);

        Task<List<SuperHero>?> AddHero(SuperHero hero);

        Task<List<SuperHero>?> UpdateHero(int id, SuperHero newhero);

        Task<List<SuperHero>?> DeleteHero(int id);

        //? came from adding it to method in class, make it nullable

    }
}

