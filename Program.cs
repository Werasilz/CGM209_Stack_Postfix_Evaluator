using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Stack
{
    class Program
    {
        private static bool isOperator;
        private static string ch;
        private static int x;
        private static int op2;
        private static int op1;
        private static int result;

        static void Main(string[] args)
        {
            // For Operator
            LStack stack = new LStack();     
            
            // For Operand
            LStack postfix = new LStack();
            
            Console.WriteLine("Enter word 'enter' for result postfix");
            Console.WriteLine("Enter word 'calculate' for finish result");
            Console.WriteLine("Enter Operand and Operator to calculate");

            while (true)
            {
                Console.Write("\n\nEnter : ");
                ch = Console.ReadLine();
                CheckOperatorInput();

                // Input is Operand then push to stack
                if (!isOperator)                                                
                {
                    if(ch.Length == 1)
                    {
                        postfix.Push(ch);
                        Calculate(stack, postfix);
                    }
                }
                // Input is Operator
                else if (isOperator)                                            
                {
                    if (stack.m_head == null)
                    {
                        PushStack(stack, postfix);
                    }
                    else
                    {
                        if (ch == "*" || ch == "/")
                        {
                            // Input <= stack.top
                            if (stack.Top() == "*" || stack.Top() == "/")
                            {
                                PopStack(stack, postfix);
                            }
                            // Input > stack.top
                            else if (stack.Top() == "+" || stack.Top() == "-" || stack.Top() == "(" || stack.Top() == ")")
                            {
                                PushStack(stack, postfix);
                            }
                        }
                        else if (ch == "+" || ch == "-")
                        {
                            // Input <= stack.top
                            if (stack.Top() == "+" || stack.Top() == "-" || stack.Top() == "*" || stack.Top() == "/")
                            {
                                PopStack(stack, postfix);
                            }
                            // Input > stack.top
                            if (stack.Top() == "(" || stack.Top() == ")")
                            {
                                PushStack(stack, postfix);
                            }
                        }
                        else if (ch == "(")
                        {
                            PushStack(stack, postfix);
                        }
                        else if (ch == ")")
                        {
                            for (int i = 0; i <= stack.m_count; i++)
                            {
                                if (stack.Top() != "(")
                                {
                                    postfix.Push(stack.Top());
                                    stack.Pop();
                                    Console.WriteLine("");
                                    Calculate(stack, postfix);
                                }
                                else if (stack.Top() == "(")
                                {
                                    stack.Pop();
                                    break;
                                }
                            }
                        }
                    }
                }

                // Enter for result Postfix
                if (ch == "enter" || ch == "Enter")
                {
                    for (int i = 0; i <= stack.m_count; i++)
                    {
                        if (stack.m_head != null)
                        {
                            postfix.Push(stack.Top());
                            stack.Pop();
                            Console.WriteLine("");
                            Calculate(stack, postfix);
                        }
                    }
                    ResultPostfix(postfix);
                }

                // Calculate for result
                if (ch == "calculate" || ch == "Calculate" || ch == "cal")
                {
                    PostfixCalculate(postfix);
                    Console.WriteLine("Result Postfix = " + result);
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void CheckOperatorInput()
        {
            if (ch == "*" || ch == "/" || ch == "+" || ch == "-" || ch == "(" || ch == ")")
            {
                isOperator = true;
            }
            else
            {
                isOperator = false;
            }
        }

        private static void Calculate(LStack stack, LStack postfix)
        {
            x += 1;
            Console.Write("\n" + x + " : ");
            Console.Write("\n  Stack = ");
            DListNode itr1 = stack.m_head;
            
            for (int i = 1; i <= stack.m_count; i++)
            {
                Console.Write(itr1.m_data);
                itr1 = itr1.m_next;
                if (itr1 == null) break;
            }

            Console.Write("\n  Postfix = ");
            DListNode itr2 = postfix.m_head;
            for (int i = 1; i <= postfix.m_count; i++)
            {
                Console.Write(itr2.m_data);
                itr2 = itr2.m_next;
                if (itr2 == null) break;
            }
        }

        private static void ResultPostfix(LStack postfix)
        {
            Console.Write("\n\nResult Postfix = ");
            DListNode itr = postfix.m_head;
            for (int i = 1; i <= postfix.m_count; i++)
            {
                Console.Write(itr.m_data);
                itr = itr.m_next;
                if (itr == null) break;
            }
            Console.WriteLine("");
        }

        private static void PushStack(LStack stack,LStack postfix)
        {
            stack.Push(ch);
            Calculate(stack, postfix);
        }

        private static void PopStack(LStack stack, LStack postfix)
        {
            postfix.Push(stack.Top());
            stack.Pop();
            stack.Push(ch);
            Console.WriteLine("");
            Calculate(stack, postfix);
        }

        private static void OperandPop(LStack resultPostfix)
        {
            resultPostfix.Pop();
            int.TryParse(resultPostfix.Top(), out op2);
            resultPostfix.Pop();
            int.TryParse(resultPostfix.Top(), out op1);
            resultPostfix.Pop();
        }

        private static void CalculateOperand(LStack resultPostfix)
        {
            if (resultPostfix.Top() == "+")
            {
                OperandPop(resultPostfix);
                result = op1 + op2;
            }
            else if (resultPostfix.Top() == "-")
            {
                OperandPop(resultPostfix);
                result = op1 - op2;
            }
            else if (resultPostfix.Top() == "*")
            {
                OperandPop(resultPostfix);
                result = op1 * op2;
            }
            else if (resultPostfix.Top() == "/")
            {
                OperandPop(resultPostfix);
                result = op1 / op2;
            }

            resultPostfix.Push(result.ToString());
        }

        private static void PostfixCalculate(LStack postfix)
        {
            DListNode itr = postfix.m_head;
            LStack resultPostfix = new LStack();

            for (int i = 1; i <= postfix.m_count; i++)
            {
                resultPostfix.Push(itr.m_data);

                if (itr.m_data == "*" || itr.m_data == "/" || itr.m_data == "+" || itr.m_data == "-")
                {
                    CalculateOperand(resultPostfix);
                }

                itr = itr.m_next;
                if (itr == null) break;
            }
        }
    }
}
