using GestioneSpese.Entities.Entities;
using System;
using System.Collections.Generic;

namespace GestioneSpese.Entities
{
    public class Categoria : IEntity
    {
        public int Id { get; set; }
        public string categoria { get; set; }


        //EF-> associazione 1: n (1 Categoria -> n Spese)
        public ICollection<Spesa> Spese { get; set; }

        public override string ToString()
        {
            return $"{Id} - {categoria}";
        }
    }
}
