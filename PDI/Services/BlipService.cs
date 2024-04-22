using Newtonsoft.Json;
using PDI.Models;


namespace PDI.Services
{
    public class BlipService : IBlipService
    {
        private readonly HttpClient _httpClient;
        public BlipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Queue>?> GetAttendanceQueuesAsync(string tenant, string authorization)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://{tenant}.http.msging.net/commands");
                var body = new CommandBody("postmaster@desk.msging.net", "get", "/teams");
                request.Content = JsonContent.Create(body);
                request.Headers.Add("Authorization", authorization);
                

                var response = await _httpClient.SendAsync(request);
                string stringResponse = await response.Content.ReadAsStringAsync();

                CommandResponse commandResponse = JsonConvert.DeserializeObject<CommandResponse>(stringResponse);

                return commandResponse.Resource.Items;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Erro ao fazer chamada HTTP: " + ex.Message);

            }
        }

        public async Task<List<QueueCreateResult>> CreateQueuesAsync(string tenant, string authorization, List<Queue> queues)
        {
            try
            {
                var request = new HttpRequestMessage();
                var body = new CommandBody();
                var result = new List<QueueCreateResult>();

                foreach (var queue in queues.OrEmptyIfNull()) {
                    request = new HttpRequestMessage(HttpMethod.Post, $"https://{tenant}.http.msging.net/commands");
                    body = new CommandBody(Guid.NewGuid().ToString(), "postmaster@desk.msging.net", "set", "/attendance-queues", "application/vnd.iris.desk.attendancequeue+json", new Resource($"{queue.Name}"));
                    request.Headers.Add("Authorization", authorization);
                    request.Content = JsonContent.Create(body);
                    var response = await _httpClient.SendAsync(request);
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    CommandResponse commandResponse = JsonConvert.DeserializeObject<CommandResponse>(stringResponse);

                    if (commandResponse.Status == "failure") {
                        result.Add(new QueueCreateResult(queue.Name, commandResponse.Reason.Description));
                    }
                    else
                    {
                        result.Add(new QueueCreateResult(queue.Name, commandResponse.Status));
                    }
                    request.Dispose();
                }
             
                return result;
            }
            catch (HttpRequestException ex)
            {
                // Log ou tratamento de erro
                throw new Exception("Erro ao fazer chamada HTTP: " + ex.Message);

            }
        }

    }
}
