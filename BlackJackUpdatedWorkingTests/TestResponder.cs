using System.Collections.Generic;
using BlackJackUpdatedWorking;

namespace BlackJackUpdatedWorkingTests
{
    public class TestResponder : IInputOutput
    {
        private readonly Queue <string>_testResponses = new Queue<string>();

        public TestResponder(string response)
        {
            _testResponses.Enqueue(response);
        }
        

        public TestResponder(IEnumerable<string> testResponse)
        {
            foreach (var response in testResponse)
            {
                _testResponses.Enqueue(response);
            }
        }
        

        public string AskQuestion(string question)
        {
            return _testResponses.Dequeue();
        }

        
        public void Output(string message)
        {
        }

    }
}