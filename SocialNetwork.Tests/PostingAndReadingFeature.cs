using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shouldly;
using SocialNetwork.ApplicationServices;
using SocialNetwork.Console;
using SocialNetwork.Domain;
using Xbehave;
using Xunit;

namespace SocialNetwork.Tests
{
    public class PostingAndReadingFeature
    {
        [Scenario]
        public void OnePostCanBeRead(
            SocialNetworkRunner socialNetwork, 
            List<string> output)
        {
            "Given the network is running"
                .x(() =>
                {
                    output = new List<string>();
                    socialNetwork = new SocialNetworkRunner(output.Add);
                });

            "And Alice posts to their personal timeline 5 minutes ago"
                .x(() =>
                {
                    var now = DateTimeOffset.UtcNow;
                    
                    SystemTime.Now = () => now.AddMinutes(-5);

                    socialNetwork.Process(() => "Alice -> I love the weather today");

                    SystemTime.Now = () => now;
                });

            "When a user requests Alice's timeline"
                .x(() => socialNetwork.Process(() => "Alice"));

            "Then Alice's update should be posted"
                .x(() => output.First().ShouldBe("Alice - I love the weather today (5 minutes ago)"));
        }

        [Scenario]
        [Example(Time.Seconds, -33, "33 seconds")]
        [Example(Time.Seconds, -3, "3 seconds")]
        [Example(Time.Minutes, -3, "3 minutes")]
        [Example(Time.Minutes, -1, "1 minute")]
        [Example(Time.Minutes, -59, "59 minutes")]
        [Example(Time.Minutes, -63, "1 hour")]
        [Example(Time.Hours, -7, "7 hours")]
        public void DisplaysTimesCorrectly(
            Time time,
            int timeQuantity,
            string expectedText,
            SocialNetworkRunner socialNetwork,
            List<string> output
        )
        {
            "Given the network is running"
                .x(() =>
                {
                    output = new List<string>();
                    socialNetwork = new SocialNetworkRunner(output.Add);
                });

           $"And Alice posts to their personal timeline {timeQuantity} {time.ToString()} ago"
                .x(() =>
                {
                    var now = DateTimeOffset.UtcNow;

                    switch (time)
                    {
                        case Time.Seconds:
                            SystemTime.Now = () => now.AddSeconds(timeQuantity);
                            break;
                        case Time.Minutes:
                            SystemTime.Now = () => now.AddMinutes(timeQuantity);
                            break;
                        case Time.Hours:
                            SystemTime.Now = () => now.AddHours(timeQuantity);
                            break;
                    }

                    socialNetwork.Process(() => "Alice -> I love the weather today");

                    SystemTime.Now = () => now;
                });

            "When a user requests Alice's timeline"
                .x(() => socialNetwork.Process(() => "Alice"));

            "Then Alice's update should be posted with the correct time"
                .x(() => output.Last().ShouldBe($"Alice - I love the weather today ({expectedText} ago)"));
        }

        public enum Time
        {
            Seconds,
            Minutes,
            Hours
        }
    }
}
