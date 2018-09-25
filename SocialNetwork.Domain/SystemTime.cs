using System;

namespace SocialNetwork.Domain
{
    public class SystemTime
    {
        public static Func<DateTimeOffset> Now = () => DateTimeOffset.UtcNow;
        public static void Reset() => Now = () => DateTimeOffset.UtcNow;
    }
}