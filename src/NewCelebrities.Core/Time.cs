namespace NewCelebrities
{
    public class Seconds
    {
        public TimeSpan TimeSpan { get; private set; }
        public void RemoveSecond() => TimeSpan = TimeSpan.Subtract(new TimeSpan(0, 0, 1));
        public bool IsUp() => TimeSpan.TotalSeconds <= 0;

        public Seconds(int seconds = 50)
        {
            TimeSpan = new TimeSpan(0, 0, seconds);
        }

        public Seconds(TimeSpan timespan)
        {
            TimeSpan = timespan;
        }

        public override string ToString() => TimeSpan.ToString();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Seconds)obj;
            return other.TimeSpan.Equals(TimeSpan);
        }

        public override int GetHashCode() => TimeSpan.GetHashCode();
    }
}
