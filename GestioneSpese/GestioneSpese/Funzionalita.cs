using GestioneSpese.EF.Repository;
using GestioneSpese.Entities.Entities;
using GestioneSpese.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese
{
   public  class Funzionalita
    {
        public static void CreazioneSpesa()
        {

            IRepositorySpese spesa = new RespositorySpesaEF() { };

            Console.WriteLine("Creazione Spesa:");
            Console.WriteLine("Inserisci Nome Utente:");
            string utente = Console.ReadLine();
            Console.WriteLine("Inserisci descrzione spesa:");
            string desc = Console.ReadLine();
            Console.WriteLine("Inserisci Categoria ID:");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci importo:");
            decimal d = Convert.ToDecimal(Console.ReadLine());

            Spesa NewSpesa = new Spesa
            {
                Utente = utente,
                Data = DateTime.Now,
                Descrizione = desc,
                CategoriaId = c,
                Approvato = false,
                Importo = d

            };
            spesa.Create(NewSpesa);
        }

        public static void EliminaSpesa()
        {
            IRepositorySpese spesa = new RespositorySpesaEF() { };
            Console.WriteLine("Inserisci Id della spesa da eliminare:");
            int id = Convert.ToInt32(Console.ReadLine());
            spesa.Delete(id);

        }
        public static void ApprovaSpesa()
        {
            IRepositorySpese spesa = new RespositorySpesaEF() { };
            Console.WriteLine("Inserisci Id della spesa da Approvare:");
            int id = Convert.ToInt32(Console.ReadLine());
            spesa.ApprovingSpesa(id);

        }

        public static void SpeseApprovate()
        {
            IRepositorySpese spesa = new RespositorySpesaEF() { };

            spesa.GetApproved();
        }

        public static void SpeseUtente()
        {
            IRepositorySpese spesa = new RespositorySpesaEF() { };
            Console.WriteLine("Inserire Nome utente:");
            InserimentoNome:
            string n = Console.ReadLine();
   
            var x=spesa.GetByUtente(n);
            if (x==false)
            {
                Console.WriteLine("Qualcosa non è andato a buon fine. Prova a reinserire il nome utente");
                goto InserimentoNome;
            }
            



        }

        public static void SpesaPerCategoria()
        {
            IRepositorySpese spesa = new RespositorySpesaEF() { };
            IRepositoryCategoria cat = new RepositoryCategoriaEF() { };
            var x= cat.AllCategorie();
            foreach (var item in x)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Inserisci id della categoria da verificare");
            int id = Convert.ToInt32(Console.ReadLine());
            var c = cat.GetbyID(id);
            spesa.TotalByCategory(c);
            
        }

    }
}
