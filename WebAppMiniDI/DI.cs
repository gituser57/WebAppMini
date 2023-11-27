namespace WebAppMiniDI
{
    interface ITimeService
    {
        string GetTime();
    }

    class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }

    class LongTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToLongTimeString();
    }

    class TimeMessage
    {
        ITimeService timeService;
        public TimeMessage(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string GetTime() => $"Time: {timeService.GetTime()}";
    }

}
