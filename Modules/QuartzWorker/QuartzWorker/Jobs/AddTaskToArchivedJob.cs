using Quartz;

namespace QuartzWorker.Jobs
{
    internal class AddTaskToArchivedJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hejka");
            return Task.CompletedTask;
        }
    }
}
