using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.Entities.Repository
{
    public interface IRepositoryCategoria: IRepository<Categoria>
    {
        public List<Categoria> AllCategorie();
    }
}
