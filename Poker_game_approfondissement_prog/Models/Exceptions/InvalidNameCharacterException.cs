using System.Diagnostics;

namespace Poker_game_approfondissement_prog.Models.Exceptions
{
    public class InvalidNameCharacterException : Exception
    {
        public InvalidNameCharacterException() { Trace.WriteLine("Le pseudonyme ne peut contenir des caractères spéciaux."); }
    }
}
