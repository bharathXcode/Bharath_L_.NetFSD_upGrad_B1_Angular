using System;
using System.Collections.Generic;

class Q4_StackUndo
{
    public static void Main()
    {
        Stack<string> actions = new Stack<string>();

        actions.Push("Type A");
        actions.Push("Delete B");
        actions.Push("Type C");
        actions.Push("Type D"); // Added to ensure Peek works

        Console.WriteLine("Undo operations:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine(actions.Pop());

        Console.WriteLine("Top after undo: " + actions.Peek());
    }
}