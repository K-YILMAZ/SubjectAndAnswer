using Data;
using RabbitMQ.Client;
using System.Text;
namespace RabbitMQService
{
    public class Publisher
    {
        private readonly RabbitMQConnectorHelper _rabbitMQConnectorHelper;

        public Publisher(string queueName, string messageJsonString)
        {
            var factory = RabbitMQConnectorHelper.GetRabbitMQConnection();
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(messageJsonString);
            channel.BasicPublish("", queueName, null, body);
        }
    }
}
