using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class Job
    {
        public readonly JobContext jobContext;

        internal Job(JobContext jobContext)
        {
            this.jobContext = jobContext;
        }

        public void Wait()
        {
            jobContext.Wait();
        }

        public void RequestPause()
        {
            jobContext.RequestPause();
        }

        public void RequestContinue()
        {
            jobContext.RequestContinue();
        }

        public void RequestStop()
        {
            jobContext.RequestStop();
        }
    }
}
