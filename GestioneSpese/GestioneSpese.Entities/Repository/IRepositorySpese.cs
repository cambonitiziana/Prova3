using GestioneSpese.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.Entities.Repository
{
    public interface IRepositorySpese: IRepository<Spesa>
    {
       void ApprovingSpesa(int id);

        void GetApproved();

        bool GetByUtente(string utente);

        void TotalByCategory(Categoria categoria);

    }
}
