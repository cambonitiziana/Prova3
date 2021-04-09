using GestioneSpese.Entities;
using GestioneSpese.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.EF.Context
{
    public class GestioneSpeseContex : DbContext
    {
        public GestioneSpeseContex() : base() { }
        public GestioneSpeseContex(DbContextOptions<GestioneSpeseContex> options) : base(options) { }

        //Tabelle da mappare: spese e categorie

        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categoria> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {


            optionBuilder.UseSqlServer(@"Persist Security Info= False; 
                                        Integrated Security = true; 
                                        Initial Catalog = SpeseManager; 
                                        Server = .\SQLEXPRESS ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Spesa>()                //ad una spesa 
                            .HasOne(r => r.Categoria)   // è associata un categoria
                            .WithMany(g => g.Spese);    // a cui possono essere associate più spese


        }
    }
}
