//			Interface

using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
	public interface ISuperHeroService
    {

        //copy paste (method names + return type) from controller here in interface
      List<SuperHero> GetAllHeroes();

       SuperHero? GetsingleHero(int id);

      List<SuperHero> AddHero(SuperHero hero);

       List<SuperHero>? UpdateHero(SuperHero newhero);

        List<SuperHero>? DeleteHero(int id);

        //? came from adding it to method in class, make it nullable

    }
}

