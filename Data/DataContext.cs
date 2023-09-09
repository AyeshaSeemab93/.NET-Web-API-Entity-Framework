
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
        //connection string, just write override config (automatically method written)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //write this to tell we want to use sql or Entity framework
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");

        }
        //create table in database.Its called property ob db set
        public DbSet<SuperHero> SuperHeroes { get; set; }


        //now register this DataContext file in program.cs
    }
}

