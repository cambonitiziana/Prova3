using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.Entities.Entities
{
    public class Spesa : IEntity
    {
        public int Id { get ; set ; }
        public DateTime Data{ get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; } //Foreign key: nome altra classe+id
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }

        public override string ToString()
        {
            return $"Spesa: {Id} {Descrizione} -{Data} - {Importo} - {Utente}";
        }
    }
}
