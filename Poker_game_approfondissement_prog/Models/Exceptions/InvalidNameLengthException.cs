using System.Diagnostics;

namespace Poker_game_approfondissement_prog.Models.Exceptions
{
    public class InvalidNameLengthException : Exception
    {
        public InvalidNameLengthException() { Trace.WriteLine("Le pseudonyme doit avoir une longueur de 3 à 21 caractères."); }
    }
}
