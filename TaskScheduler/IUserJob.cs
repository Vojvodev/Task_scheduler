namespace TaskScheduler
{
    public interface IUserJob
    {
        protected internal void Run(IJobContext jobApi);
    }
}
