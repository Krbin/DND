using System.Runtime.CompilerServices;

namespace messagebuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BufferSize = 5;

            MessageBuffer buffer = new MessageBuffer(BufferSize);

            for (int i = 0; i < (BufferSize + BufferSize % 2) / 2 * 3; i++)
            {
                Console.WriteLine($"message: \"{i}\"\n Print: ");

                buffer.Send($"{i}");
                buffer.Print();
                System.Console.WriteLine("end \n");
            }
        }

        class MessageBuffer
        {
            private int index;
            private int bufferSize = 0;
            private int numberOfMessages = 0;
            private string[] buffer;
            public MessageBuffer(int bufferSize)
            {
                this.bufferSize = bufferSize;

                this.index = bufferSize;
                this.buffer = new string[bufferSize];
            }

            public void Send(string message)
            {
                this.index = (this.bufferSize + (this.index - 1)) % this.bufferSize;

                this.buffer[this.index] = message;

                if (this.numberOfMessages < this.bufferSize)
                {
                    this.numberOfMessages++;
                }
            }

            public void Print()
            {


                for (int i = this.index; i < this.index + this.numberOfMessages; i++)
                {
                    System.Console.WriteLine(this.buffer[(i % this.bufferSize)]);
                }
            }
        }
    }
}