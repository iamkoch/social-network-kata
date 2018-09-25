using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shouldly;
using SocialNetwork.ApplicationServices;
using SocialNetwork.Console;
using Xbehave;
using Xunit;

namespace SocialNetwork.Tests
{
    public class PostingAndReadingFeature
    {
        [Scenario]
        public void OnePostCanBeRead(
            SocialNetworkRunner socialNetwork, List<string> output)
        {
            "Given the network is running"
                .x(() =>
                {
                    output = new List<string>();
                    socialNetwork = new SocialNetworkRunner(output.Add);
                });

            "And Alice posts to their personal timeline"
                .x(() => socialNetwork.Process(() => "Alice -> I love the weather today"));

            "When a user requests Alice's timeline"
                .x(() => socialNetwork.Process(() => "Alice"));

            "Then Alice's update should be posted"
                .x(() => output.First().ShouldBe("Alice - I love the weather today (5 minutes ago)"));
        }
    }
}
