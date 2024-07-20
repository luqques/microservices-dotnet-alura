using ItemService.Dtos;
using RabbitMQ.Client;

namespace ItemService.RabbitMqClient
{
    public class RabbitMqSubscriber
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _nomeDaFila;

        public RabbitMqSubscriber(IConfiguration configuration, string nomeDaFila)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory() { HostName = _configuration["RabbitMq.Host"], Port = Int32.Parse(_configuration["RabbitMq.Port"]) }.CreateConnection(); ;
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _nomeDaFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeDaFila, exchange: "trigger", routingKey: "");
        }
    }
}
