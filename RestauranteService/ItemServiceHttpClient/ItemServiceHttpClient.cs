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
        private readonly IRabbitMqClient _rabbitMqClient;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration, IRabbitMqClient rabbitMqClient)
        {
            _client = client;
            _configuration = configuration;
            _rabbitMqClient = rabbitMqClient;
        }

        public void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            _rabbitMqClient.PublicarRestaurante(readDto);
        }
    }
}
