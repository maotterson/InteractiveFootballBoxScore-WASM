using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser.Models
{
    internal interface IPlayEvent
    {
        public string PlayType { get; set; }
        public bool isScoringPlay();
    }
}
