using dt191g_mom4.Models;
using Microsoft.EntityFrameworkCore;


namespace dt191g_mom4.Data;

public class MusicDbContext : DbContext 
{    
    //Konstruktur
    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }     //Databasanslutning

    //Tabeller
    public DbSet<Music> Music { get; set; } //Skapar tabellen Music utifrån modellen Music

}

