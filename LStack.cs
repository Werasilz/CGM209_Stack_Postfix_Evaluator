using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Stack
{
    class LStack : DLinkList
    {
        public void Push(string p_data) => Append(p_data);

        public void Pop() => RemoveTail();

        public string Top() => m_tail.m_data;

        public int Count => m_count;
    }
}
