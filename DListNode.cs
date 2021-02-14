using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Stack
{
    class DListNode
    {
        public string m_data;
        public DListNode m_next;
        public DListNode m_previous;

        public DListNode(string value)
        {
            m_data = value;
            m_next = null;
            m_previous = null;
        }

        public DListNode InsertAfter(string p_data)
        {
            DListNode newNode = new DListNode(p_data);
            newNode.m_next = m_next;

            if (m_next != null)
            {
                m_next.m_previous = newNode;
            }

            m_next = newNode;
            newNode.m_previous = this;

            return newNode;
        }

        public DListNode InsertBefore(string p_data)
        {
            DListNode newNode = new DListNode(p_data);
            newNode.m_previous = m_previous;

            if (m_previous != null)
            {
                m_previous.m_next = newNode;
            }

            m_previous = newNode;
            newNode.m_next = this;

            return newNode;
        }
    }
}
