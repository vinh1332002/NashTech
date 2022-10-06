namespace ClockAssignment
{
    public class DisplayClock
    {
        public void Subcribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(ShowClock);
        }

        public void ShowClock(object clock, ClockEventArgs time)
        {
            Console.WriteLine($"{time.hour} : {time.minute} : {time.second}");
        }
    }
}