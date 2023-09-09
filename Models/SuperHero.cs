using System;
namespace SuperHeroApi.Models
{
	public class SuperHero
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? address { get; set; }


        //? and string.Empty work here same
        //means can be null/empty
    }
}

