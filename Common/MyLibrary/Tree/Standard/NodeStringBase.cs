using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Tree.Standard
{
    public abstract class NodeStringBase
    {
        public NodeStringBase(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString() => $"Node:{Value}";
    }
}
