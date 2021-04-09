using GestioneSpese.EF.Context;
using GestioneSpese.Entities;
using GestioneSpese.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneSpese.EF.Repository
{
    public class RepositoryCategoriaEF : IRepositoryCategoria
    {
        public List<Categoria> AllCategorie()
        {
            using (var ctx = new GestioneSpeseContex())
            {

                return ctx.Categorie.ToList();

            }
        }
        public bool Create(Categoria item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria GetbyID(int id)
        {
            using (var ctx = new GestioneSpeseContex())
            {

                return ctx.Categorie.Find(id);

            }
        }

        public bool Update(Categoria item)
        {
            throw new NotImplementedException();
        }
    }
}
