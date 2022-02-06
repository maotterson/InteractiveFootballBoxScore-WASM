using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayByPlayParser.Models
{
    public class Play
    {
        public int PlayIndex { get; set; }
        public string? Quarter { get; set; }
        public string? Time { get; set; }
        public string? Down { get; set; }
        public string? ToGo { get; set; }
        public string? Location { get; set; }
        public string? Summary { get; set; }

        public IPlayEvent? PlayEvent { get; set; }
    }
}
