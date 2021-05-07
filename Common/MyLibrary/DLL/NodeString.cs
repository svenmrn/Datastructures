using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DLL
{
    public class NodeString : SLL.NodeIntBase
    {
        private NodeString next, prev;

        public NodeString(int value) : base(value) { }

        /// <summary>
        /// While setting the Next, we always assure that that node points also to this node
        /// </summary>
        public NodeString Next
        {
            get
            {
                return next;
            }
            internal set
            {
                this.next = value;    
                if (value != null && !ReferenceEquals(value.Prev, this))
                    value.Prev = this;
            }
        }

        /// <summary>
        /// While setting the Previous, we always assure that that node points also to this node
        /// </summary>
        public NodeString Prev
        {
            get
            {
                return prev;
            }
            internal set
            {
                prev = value;
                if (value != null && !ReferenceEquals(value.Next, this))
                    prev.Next = this;
            }
        }
    }
}
