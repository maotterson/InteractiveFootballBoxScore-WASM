using PlayByPlayParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser.PlayEvent
{
    internal class ExtraPointEvent : IPlayEvent
    {
        public string PlayType { get; set; } = "ExtraPoint";
        public string? Kicker { get; set; }
        public bool isSuccessful { get; set; }

        public bool isScoringPlay()
        {
            if (isSuccessful)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string patString = $"{PlayType} - Kicker: {Kicker}, ";
            patString += isSuccessful ? "Good" : "Missed";
            return patString;
        }
    }
}
