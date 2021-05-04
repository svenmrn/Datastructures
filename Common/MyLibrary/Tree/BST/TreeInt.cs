using MyLibrary.Tree.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Tree.BST
{

    /// <summary>
    /// This class represents a Binary Search Tree
    /// </summary>
    public class TreeInt
    {
        public NodeInt Root { get; private set; }

        #region public area
        public NodeInt Insert(int value)
        {
            var newNode = new NodeInt(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var node = FindNode(Root, value);
                if (node.Value == value)        // value already present
                    return node;
                else if (node.Value > value)
                {
                    node.Left = newNode;
                }
                else
                    node.Right = newNode;
            }
            return newNode;
        }

        public NodeInt FindNode(int value)
        {
            var node = FindNode(Root, value);       // This will return the parent if the node is not present
            if (node.Value != value)
                return null;

            return node;
        }

        public int Remove(int value)
        {
            //var node = FindNode(value);
            //if (node != null)
            return 0;
        }
        #endregion

        #region private parts
        private NodeInt FindNode(NodeInt parent, int value)
        {
            NodeInt temp;

            if (parent == null)
                return parent;

            if (parent.Value == value)
                temp = parent;
            else if (parent.Value > value)
                temp = FindNode(parent.Left, value);
            else
                temp = FindNode(parent.Right, value);

            return (temp == null ? parent : temp);
        }
        #endregion
    }
}
