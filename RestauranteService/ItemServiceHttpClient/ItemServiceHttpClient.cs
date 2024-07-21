using RestauranteService.Dtos;
using RestauranteService.RabbitMqClient;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly IRabbitMqClient _rabbitMqClient;

        public ItemServiceHttpClient(IRabbitMqClient rabbitMqClient)
        {
            _rabbitMqClient = rabbitMqClient;
        }

        public void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            _rabbitMqClient.PublicarRestaurante(readDto);
        }
    }
}
