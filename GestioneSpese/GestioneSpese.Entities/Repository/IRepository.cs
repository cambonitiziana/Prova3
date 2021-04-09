using GestioneSpese.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.Entities.Repository
{
   public  interface IRepository<T> where T: IEntity
    {
        //CRUD
        bool Create(T item);
        bool Delete(int id);
        T GetbyID(int id);
        bool Update(T item);
    }
}
