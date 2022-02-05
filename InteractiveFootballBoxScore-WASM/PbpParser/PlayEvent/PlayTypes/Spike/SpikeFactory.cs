using PlayByPlayParser.PlayEvent.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser.PlayEvent.PlayTypes.Spike
{
    internal class SpikeFactory
    {
        public static SpikeEvent? Create(string summary)
        {
            SpikeEvent? playEvent = null;

            playEvent = new SpikeEvent
            {
                Passer = SummaryDataExtractor.extractSpikePasser(summary)
            };

            return playEvent;
        }
    }
}
