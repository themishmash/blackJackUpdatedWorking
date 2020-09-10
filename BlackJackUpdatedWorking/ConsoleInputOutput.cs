using System;

namespace BlackJackUpdatedWorking
{
    public class ConsoleInputOutput : IInputOutput
    {
        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}