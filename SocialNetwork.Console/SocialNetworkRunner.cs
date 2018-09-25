using System;
using System.Linq;
using SocialNetwork.ApplicationServices;

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

            var command = CommandFactory.CreateFromInvocation(inputResult);

            var output = CommandHandler.Handle(command);

            if (output.Any())
                output.ForEach(x => _outputHandler(x));

            return true;
        }
    }
}