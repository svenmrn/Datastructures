using MyLibrary.SLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Tree.Standard
{
    public class NodeString : NodeStringBase
    {
        public NodeString(string value): base(value)
        {
        }

        public DLL.ListString Children { get; private set; } = new DLL.ListString();

        //public Add
    }
}
