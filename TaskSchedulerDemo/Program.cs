﻿using TaskScheduler;
using TaskSchedulerDemo;

TaskScheduler.TaskScheduler taskScheduler = new()
{
    MaxConcurrentTasks = 1
};

Job jobA = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
{
    Name = "Job A",
    NumIterations = 15,
    SleepTime = 500
}) { Priority = 4 });

Job jobB = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
{
    Name = "Job B",
    NumIterations = 5,
    SleepTime = 500
}) { Priority = 5 });

Job jobX = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
{
    Name = "Job X",
    NumIterations = 10,
    SleepTime = 500
}) { Priority = 1 });

Job jobZ = taskScheduler.Schedule(new JobSpecification(new DemoUserJob()
{
    Name = "Job Z",
    NumIterations = 10,
    SleepTime = 500
})
{ Priority = 1 });

Thread.Sleep(1000);
//Console.WriteLine("Requesting pause on jobX");
jobA.RequestStop();

/*Thread.Sleep(3000);
Console.WriteLine("Requesting continue on jobX");*/
//jobX.RequestContinue();
