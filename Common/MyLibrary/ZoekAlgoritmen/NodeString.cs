using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.ZoekAlgoritmen
{
    public class NodeString
    {
        public NodeString(string value)
        {
            this.Value = value;
        }
        public string Value { get; set; }
        public NodeString Next { get; internal set; }
        public override string ToString()
        {
            return $"{this.Value}" + (Next != null ? " - " + Next.ToString() : "");
        }
    }
}
