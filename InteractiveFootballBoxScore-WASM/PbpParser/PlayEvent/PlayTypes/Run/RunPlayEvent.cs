using PlayByPlayParser.Models;
using PlayByPlayParser.PlayEvent.PlayTypes.Pass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser.PlayEvent
{
    internal class RunPlayEvent : IPlayEvent
    {
        public string PlayType { get; set; } = "Run";
        public int RushingYards { get; set; }
        public string? Carrier { get; set; }
        public List<string>? Tacklers { get; set; }
        public RunType? RunType { get; set; }
        public bool IsTouchdown { get; set; }

        public override string ToString()
        {
            string runString = $"{PlayType} - Type: {RunType}, Carrier: {Carrier}, Yards: {RushingYards}";

            // add potential concluding events
            if (IsTouchdown)
            {
                runString += $", TOUCHDOWN";
            }
            else if(Tacklers != null)
            {
                runString += $", Tacklers: ";
                foreach (string t in Tacklers)
                {
                    runString += $"{t}, ";
                }
            }

            return runString;
        }
        public bool isScoringPlay()
        {
            if (IsTouchdown)
            {
                return true;
            }
            return false;
        }

    }
}
