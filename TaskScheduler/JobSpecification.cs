namespace TaskScheduler
{
    public class JobSpecification
    {
        internal IUserJob UserJob { get; }
        public int Priority { get; init; } = 0;
        public JobSpecification(IUserJob userJob)
        {
            UserJob = userJob;
        }
    }
}
