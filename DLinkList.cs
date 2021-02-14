using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Stack
{
    class DLinkList
    {
        public DListNode m_head;
        public DListNode m_tail;
        public int m_count;

        public DLinkList()
        {
            DListNode itr = m_head;
            DListNode next;
            while (itr != null)
            {
                next = itr.m_next;
                itr = null;
                itr = next;
            }
        }

        public void Append(string p_data)
        {
            if (m_head == null)
            {
                m_head = m_tail = new DListNode(p_data);
            }
            else
            {
                m_tail.InsertAfter(p_data);
                m_tail = m_tail.m_next;
            }
            m_count++;
        }

        public void Prepend(string p_data)
        {
            if (m_tail == null)
            {
                m_tail = m_head = new DListNode(p_data);
            }
            else
            {
                m_head.InsertBefore(p_data);
                m_head = m_head.m_previous;
            }
            m_count++;
        }

        public void RemoveHead()
        {
            DListNode node = null;
            if (m_head != null)
            {
                node = m_head.m_next;
                m_head.m_data = null;
                m_head = node;
                if (m_head == null)
                {
                    m_tail = null;
                }
                m_count--;
            }
        }

        public void RemoveTail()
        {
            DListNode node = null;
            if (m_tail != null)
            {
                node = m_tail.m_previous;
                m_tail.m_data = null;
                m_tail = node;
                if (m_tail == null)
                {
                    m_head = null;
                }
                m_count--;
            }
        }

        public DListIterator GetIterator()
        {
            return new DListIterator(this, m_head);
        }

        public void Insert(DListIterator p_iterator, string p_data)
        {
            if (p_iterator.m_list != this)
            {
                return;
            }

            if (p_iterator.m_node != null)
            {
                p_iterator.m_node.InsertAfter(p_data);

                if (p_iterator.m_node == m_tail)
                {
                    m_tail = p_iterator.m_node.m_next;
                }
                m_count++;
            }
            else
            {
                Append(p_data);
            }
        }

        public void Remove(DListIterator p_iterator, DListNode node)
        {
            if (p_iterator.m_list != this)
                return;

            if (p_iterator.m_node == null)
                return;

            if (p_iterator.m_node == m_head)
            {
                p_iterator.Forth();
                RemoveHead();
            }
            else
            {
                while (node.m_next != p_iterator.m_node)
                    node = node.m_next;

                p_iterator.Forth();

                if (node.m_next == m_tail)
                    m_tail = node;

                node.m_next = null;
                node.m_next = p_iterator.m_node;
            }
            m_count--;
        }
    }
}
