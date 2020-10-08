using System;

namespace Pimsporter.Adapter
{
    class ConsoleWrapper : IConsoleWrapper
    {
        public string GetUsername()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            return username;
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

    }

    public interface IConsoleWrapper
    {
        string GetUsername();

        void Write(string value);
        void Write(string format, params object[] args);
        void WriteLine();
        void WriteLine(string value);
        void WriteLine(string format, params object[] args);
        ConsoleKeyInfo ReadKey(bool intercept);
        string ReadLine();
    }
}
