using PlayByPlayParser.Models;
using PlayByPlayParser.PlayEvent;
using PlayByPlayParser.PlayEvent.Helpers;
using PlayByPlayParser.PlayEvent.PlayTypes.ExtraPoint;
using PlayByPlayParser.PlayEvent.PlayTypes.FieldGoal;
using PlayByPlayParser.PlayEvent.PlayTypes.Kickoff;
using PlayByPlayParser.PlayEvent.PlayTypes.Kneel;
using PlayByPlayParser.PlayEvent.PlayTypes.Pass;
using PlayByPlayParser.PlayEvent.PlayTypes.Penalty;
using PlayByPlayParser.PlayEvent.PlayTypes.Punt;
using PlayByPlayParser.PlayEvent.PlayTypes.Spike;
using PlayByPlayParser.PlayEvent.PlayTypes.TwoPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser
{
    internal static class PlayEventFactory
    {
        public static Dictionary<string, Func<string, IPlayEvent>> PlayKeywordDictionary = new Dictionary<string, Func<string, IPlayEvent>>
        {
            { "kicks off", x => KickoffEventFactory.Create(x) },
            { "pass", x => PassPlayEventFactory.Create(x) },
            { "up the middle" , x => RunPlayEventFactory.Create(x) },
            { "right end" , x => RunPlayEventFactory.Create(x) },
            { "left end" , x => RunPlayEventFactory.Create(x) },
            { "right tackle" , x => RunPlayEventFactory.Create(x) },
            { "left tackle" , x => RunPlayEventFactory.Create(x) },
            { "right guard" , x => RunPlayEventFactory.Create(x) },
            { "left guard" , x => RunPlayEventFactory.Create(x) },
            { "Penalty", x => PenaltyEventFactory.Create(x) },
            { "kicks extra point", x => ExtraPointFactory.Create(x) },
            { "sacked", x => SackFactory.Create(x) },
            { "field goal", x => FieldGoalFactory.Create(x) },
            { "kneels", x => KneelFactory.Create(x) },
            { "punts", x => PuntFactory.Create(x) },
            { "Two Point Attempt:", x => TwoPointFactory.Create(x) },
            { "spiked the ball", x => SpikeFactory.Create(x) }
        };

        public static IPlayEvent? ExtractPlayEvent(string summary)
        {
            IPlayEvent? playEvent = null;

            // check for the type of play based on keyword phrases
            foreach(string keyPhrase in PlayKeywordDictionary.Keys)
            {
                if (summary.Contains(keyPhrase))
                {
                    playEvent = PlayKeywordDictionary[keyPhrase](summary);
                    return playEvent;
                }
            }

            return playEvent;
        }
    }
}
