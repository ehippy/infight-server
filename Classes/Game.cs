using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Infight
{
    public class InfightContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=infight;User Id=infight; Password=infight;");
        }
    }

    public class Team
    {
        public int Id {get; set;}
        public string Domain {get; set;}
        public string ImgUrl {get; set;}
        public List<Player> Users {get; set;}
        public DateTime Created {get; set;}
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int TeamDomain { get; set; }
        public Team Team { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public string TeamDomain { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Unit> Units { get; set; }
    }

    public class Unit {
        public int Id {get; set; }
        public Player Player {get; set; }
        public int ActionPoints {get; set; }
        public int HealthPoints {get; set; }
        public int Range {get; set; }
        public int PositionX {get; set; }
        public int PositionY {get; set; }
    }
}