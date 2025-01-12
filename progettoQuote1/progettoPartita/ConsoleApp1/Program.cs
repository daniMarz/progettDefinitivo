using System;
using System.Collections.Generic;
using System.Globalization;

// Definizione di una classe Partita con le informazioni (squadre e quote)
public class Partita
{
    public string SquadraCasa { get; set; }
    public string SquadraTrasferta { get; set; }
    public double Quota { get; set; }

    public Partita(string squadraCasa, string squadraTrasferta, double quota)
    {
        SquadraCasa = squadraCasa;
        SquadraTrasferta = squadraTrasferta;
        Quota = quota;
    }

    public override string ToString()
    {
        return $"{SquadraCasa} vs {SquadraTrasferta} - Quota: {Quota}";
    }
}

// Classe principale
public class Program
{
    public static List<Partita> partite = new List<Partita>();

    public static void AggiungiPartita(string squadraCasa, string squadraTrasferta, double quota)
    {
        Partita partita = new Partita(squadraCasa, squadraTrasferta, quota);
        partite.Add(partita);
    }

    public static void TrovaPartitePerQuota(double quota)
    {
        bool trovato = false;
        foreach (var partita in partite)
        {
            if (Math.Abs(partita.Quota - quota) < 0.0001) // Confronto per valori decimali
            {
                Console.WriteLine(partita.ToString());
                trovato = true;
            }
        }

        if (!trovato)
        {
            Console.WriteLine("Nessuna partita trovata con questa quota!");
        }
    }

    public static void Main(string[] args)
    {
        // Aggiungi alcune partite di esempio
        AggiungiPartita("Juventus", "Inter", 1.75);
        AggiungiPartita("Milan", "Napoli", 2.20);
        AggiungiPartita("Roma", "Fiorentina", 1.80);
        AggiungiPartita("Lazio", "Atalanta", 2.20);

        Console.WriteLine("Inserisci la quota da cercare: ");
        string inputQuota = Console.ReadLine()?.Trim();

        // Sostituisci la virgola con il punto per garantire il parsing corretto
        inputQuota = inputQuota.Replace(',', '.');

        if (double.TryParse(inputQuota, NumberStyles.Any, CultureInfo.InvariantCulture, out double quotaCercata))
        {
            TrovaPartitePerQuota(quotaCercata);
        }
        else
        {
            Console.WriteLine("Formato numero non valido. Assicurati di inserire un numero valido (es. 1.75 o 1,75).");
        }
    }
}