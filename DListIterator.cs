using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Stack
{
    class DListIterator
    {
        public DListNode m_node;
        public DLinkList m_list;

        public DListIterator(DLinkList p_list = null, DListNode p_node = null)
        {
            m_list = p_list;
            m_node = p_node;
        }

        public void Start()
        {
            if (m_list != null)
            {
                m_node = m_list.m_head;
            }
        }

        public void Forth()
        {
            if (m_node != null)
            {
                m_node = m_node.m_next;
            }
        }

        public string Item() { return m_node.m_data; }

        public bool Valid() { return m_node != null; }
    }
}
