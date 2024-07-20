using RestauranteService.Dtos;
using RestauranteService.RabbitMqClient;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private IRabbitMqClient _rabbitMqClient;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            _rabbitMqClient.PublicarRestaurante(readDto);

           // var conteudoHttp = new StringContent
           //     (
           //         JsonSerializer.Serialize(readDto),
           //         Encoding.UTF8,
           //         "application/json"
           //     );
           //
           // await _client.PostAsync(_configuration["ItemService"], conteudoHttp);
        }
    }
}
