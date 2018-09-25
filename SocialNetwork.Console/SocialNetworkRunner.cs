using System;

namespace SocialNetwork.Console
{
    public class SocialNetworkRunner
    {
        private readonly Action<string> _outputHandler;

        public SocialNetworkRunner(Action<string> outputHandler)
        {
            _outputHandler = outputHandler;
        }

        public bool Process(Func<string> input)
        {
            var inputResult = input();

            if (string.IsNullOrWhiteSpace(inputResult))
                return false;

            return true;
        }
    }
}