using GestioneSpese.EF.Context;
using GestioneSpese.Entities;
using GestioneSpese.Entities.Entities;
using GestioneSpese.Entities.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneSpese.EF.Repository
{
    public class RespositorySpesaEF : IRepositorySpese
    {
        public void  ApprovingSpesa(int id)
        {
            using (var ctx = new GestioneSpeseContex())
            {
                bool saved = false;
                do
                {
                    try
                    {
                       var spesa = ctx.Spese.Include(c => c.Categoria)
                                 .FirstOrDefault(x => x.Id== id);
                        spesa.Approvato = true;
                        ctx.Entry<Spesa>(spesa).State = EntityState.Modified;
                        ctx.SaveChanges();

                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entity in ex.Entries)
                        {
                            var dbValue = entity.GetDatabaseValues();
                            entity.OriginalValues.SetValues(dbValue);

                        }
                    }

                } while (!saved);

            }
           
        }

        public bool Create(Spesa item)
        {
            using (var ctx = new GestioneSpeseContex())
            {
                if (item == null)
                {
                    return false;
                }

                var categoria = ctx.Categorie.Include(c=> c.Spese)
                                                   .Where(c => c.Id == item.CategoriaId)
                                                   .SingleOrDefault();
                if (categoria != null)
                {
                    categoria.Spese.Add(item); //Aggiungo alle spese della relativa categoria
                }
                
                ctx.Spese.Add(item);
                ctx.SaveChanges();
                return true;
            }
        }
        public bool Delete(int id)
        {

            using (var ctx = new GestioneSpeseContex())
            {
                if (id < 0)
                {
                    return false; // l'id non può essere negativo
                }

                var spesa = ctx.Spese.Find(id); 
                
                if (spesa != null)
                {
                    ctx.Spese.Remove(spesa);
                    ctx.SaveChanges();
                }
                
                return true;
            }
        }

        public void GetApproved()
        {
            List<Spesa> spese = new List<Spesa>();
            using (var ctx = new GestioneSpeseContex ())
            {
                
               
              spese= ctx.Spese.Include(c=>c.Categoria)
                                .Where(x => x.Approvato == true).ToList();

            }
            Console.WriteLine("Spese approvate:");
            foreach (var item in spese)
            {
                Console.WriteLine(item.ToString());
            }
            
           
        }

        public void GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetByUtente(string utente)
        {
            List<Spesa> spese = new List<Spesa>();
            using (var ctx = new GestioneSpeseContex())
            {
                try
                {
                    spese = ctx.Spese.Include(c => c.Categoria)
                                      .Where(x => x.Utente == utente).ToList();


                    Console.WriteLine($"Spese utente: {utente}");
                    foreach (var item in spese)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return true;
                }
                catch
                (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public void TotalByCategory(Categoria categoria)
        {
            decimal d;
            using (var ctx = new GestioneSpeseContex())
            {

                 d= ctx.Spese.Where(c => c.CategoriaId == categoria.Id).Sum(a=> a.Importo);

            }
            Console.WriteLine($"Spese totali della categoria: {categoria.categoria} pari : {d}");
           
               
            
        }

        public bool Update(Spesa item)
        {
            throw new NotImplementedException();
        }

        Spesa IRepository<Spesa>.GetbyID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
