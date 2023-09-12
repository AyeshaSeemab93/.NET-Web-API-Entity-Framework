
global using Microsoft.EntityFrameworkCore;  //make using global

namespace SuperHeroApi.Data
{

    //Inherit DbContext and add usings by click on red
    public class DataContext : DbContext
    {
        //constructor
        //DB Context option of DataContext name:option :  inherit base constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }




       //creating table here with name SuperHeroes in database
        public DbSet<SuperHero> SuperHeroes { get; set; }


        //now register this DataContext file in program.cs
    }
}

