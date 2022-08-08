using RabbitMQ.Client;

namespace RabbitMQService
{
    public class RabbitMQConnectorHelper
    {

        public static RabbitMQConnectorHelper _rabbitMQConnectorHelper;
        public static ConnectionFactory _factory;
        public static ConnectionFactory GetRabbitMQConnection()
        {
            if (_rabbitMQConnectorHelper == null)
            {
                _factory = new ConnectionFactory();
                _factory.Uri = new Uri("amqp://localhost");
                _rabbitMQConnectorHelper = new RabbitMQConnectorHelper();
                
            }
            return _factory;
        }
    }
}