using GestioneSpese.EF.Repository;
using GestioneSpese.Entities.Entities;
using GestioneSpese.Entities.Repository;
using System;

namespace GestioneSpese
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine(">>>Gestione Spese<<< ");
            Console.WriteLine("Premi I per inserire una registrare una nuova spesa\n" +
                                "Premi E per eliminare una spesa\n" +
                                "Premi A per approvare una spesa\n" +
                                "Premi S per vedere tutte le tue spese approvate\n" +
                                "Premi U per vedere le spese di uno specifico utente\n" +
                                "Premi W per vedere la spesa totale per categoria ");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "i":
                    Funzionalita.CreazioneSpesa();
                    goto Start;
                case "e":
                    Funzionalita.EliminaSpesa();
                    goto Start;
                case "a":
                    Funzionalita.ApprovaSpesa();
                    goto Start;
                case "s":
                    Funzionalita.SpeseApprovate();
                    goto Start;
                case "u":
                    Funzionalita.SpeseUtente();
                    goto Start;
                case ("w"):
                    Funzionalita.SpesaPerCategoria();
                    goto Start;




            }
          


        }
    }
}
