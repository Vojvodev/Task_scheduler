using TaskScheduler;

namespace TaskSchedulerDemo
{
    public class DemoUserJob : IUserJob
    {
        public string Name { get; init; } = "DemoUserJob";
        public int NumIterations = 100;
        public int SleepTime = 500; // ms
        public void Run(IJobContext jobApi)
        {
            Console.WriteLine($"{Name} started.");
            
            for (int i = 0; i < NumIterations; i++)
            {
                Console.WriteLine($"{Name}: {i}");
                Thread.Sleep(SleepTime);
                jobApi.CheckForPause();
                if(jobApi.CheckForStop())
                {
                    Console.WriteLine("Stopped!");
                    break;
                }
            }
            
            Console.WriteLine($"{Name} finished.");
        }
    }
}
