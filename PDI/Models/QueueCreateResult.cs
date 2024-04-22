namespace PDI.Models
{
    public class QueueCreateResult
    {
        public string? QueueName { get; set; }
        public string? Result { get; set; }

        public QueueCreateResult(string queueName, string result)
        {
            QueueName = queueName;
            Result = result;
        }
    }
    
}
