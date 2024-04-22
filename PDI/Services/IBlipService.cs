using PDI.Models;

namespace PDI.Services
{
    public interface IBlipService
    {
        Task<List<Queue>?> GetAttendanceQueuesAsync(string tenant, string authorization);

        Task<List<QueueCreateResult>> CreateQueuesAsync(string tenant, string authorization, List<Queue> queues);
    }
}
