
namespace MVOP_Events
{
    public enum StackEmptyCause
    {
        EmptyStack,
        LastItemRemoved,
        StackCleared
    }
    class Program
    {
        public static void Main(string[] args)
        {
            AlertingStack<int> alertingStack = new AlertingStack<int>();

            alertingStack.OnStackEmpty += WriteWarningToConsole;
            alertingStack.Push(5);
            alertingStack.Pop();
            alertingStack.Clear();

        }

        public static void WriteWarningToConsole(StackEmptyCause s)
        {
            switch (s)
            {
                case StackEmptyCause.EmptyStack:
                    Console.WriteLine($"The stack was empty before operation");
                    break;
                case StackEmptyCause.LastItemRemoved:
                    Console.WriteLine($"Last item was removed");
                    break;
                case StackEmptyCause.StackCleared:
                    Console.WriteLine($"Stack was cleared");
                    break;
                default:
                    Console.WriteLine($"Unknown call");
                    break;
            }
        }
    }

    public delegate void WarningAction();
    public delegate void StackEmpty(StackEmptyCause e);
    public class AlertingStack<T> : Stack<T>
    {
        public event WarningAction? OnWarning;
        public event StackEmpty? OnStackEmpty;

        public AlertingStack() : base() { }
        public new void Push(T t)
        {
            base.Push(t);
        }

        public new T Pop()
        {
            if (base.Count == 0)
            {
                OnStackEmpty?.Invoke(StackEmptyCause.EmptyStack);
            }
            if (base.Count == 1)
            {
                OnStackEmpty?.Invoke(StackEmptyCause.LastItemRemoved);
            }
            return base.Pop();
        }

        public new void Clear()
        {
            base.Clear();
            OnStackEmpty?.Invoke(StackEmptyCause.StackCleared);
        }
    }
}