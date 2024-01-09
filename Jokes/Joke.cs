using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jokes
{
    internal class Joke
    {
        public bool Error { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string? joke { get; set; }
        public string? Setup { get; set; }
        public string? Delivery { get; set; }

        public Flags Flags { get; set; }

        public bool Safe { get; set; }
        public int Id { get; set; }
        public string Lang { get; set; }
    }
}
