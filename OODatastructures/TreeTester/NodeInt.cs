using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTester
{
    /// <summary>
    /// This Node class should be moved to the Class library.
    /// It represents 1 node in a Binary Tree
    /// </summary>
    public class NodeInt
    {
        public NodeInt(int value)
        {
            this.Value = value;
        }

        public NodeInt Left { get; set; }
        public NodeInt Right { get; set; }
        public int Value { get; set; }

    }
}
