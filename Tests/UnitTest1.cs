using TaskScheduler;
using TaskSchedulerDemo;

namespace Tests
{
    public class Tests
    {
        TaskScheduler.TaskScheduler taskScheduler = new()
        {
            MaxConcurrentTasks = 1
        };
        Job jobA, jobB;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestJobPausing()
        {
            jobA = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
            {
                Name = "Job A",
                NumIterations = 20,
                SleepTime = 500
            })
            { Priority = 4 });
            Thread.Sleep(500); //posao zapoceo
            jobA.RequestPause();
            Thread.Sleep(1000);
            Assert.IsTrue(jobA.jobContext.GetJobState() == JobContext.JobState.Paused);
            Thread.Sleep(1000);
            jobA.RequestContinue();
            Thread.Sleep(1000);
            Assert.IsTrue(jobA.jobContext.GetJobState() == JobContext.JobState.Running);
        }


        [Test]
        public void TestJobStoppage()
        {
            jobA = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
            {
                Name = "Job A",
                NumIterations = 20,
                SleepTime = 500
            })
            { Priority = 4 });
            jobB = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
            {
                Name = "Job B",
                NumIterations = 20,
                SleepTime = 500
            })
            { Priority = 4 });
            Thread.Sleep(500); //posao zapoceo
            jobA.RequestStop();
            Thread.Sleep(1000);
            Assert.IsTrue(jobA.jobContext.GetJobState() == JobContext.JobState.Stopped);
            Thread.Sleep(2000);
            Assert.IsTrue(jobB.jobContext.GetJobState() == JobContext.JobState.Running);
        }
    }
}