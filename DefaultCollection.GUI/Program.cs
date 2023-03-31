using DefaultCollection.Core;

var stack = new MyStack<string>();
stack.Push("First");
stack.Push("Second");
stack.Push("Third");
Console.WriteLine(stack.Count);
Console.WriteLine(stack.Peek());
stack.Pop();
Console.WriteLine(stack.Count);
Console.WriteLine(stack.Peek());
stack.Pop();
Console.WriteLine(stack.Peek());