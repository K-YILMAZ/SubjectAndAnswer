using Data;
using Microsoft.Extensions.Hosting;
using MongoDbService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQService
{
    public class ConsumerAnswerBackgroundService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private ConnectionFactory _factory;
        private EventingBasicConsumer _consumer;

        public override Task StartAsync(CancellationToken cancellationToken)
        {

            // create connection  

            _factory = RabbitMQConnectorHelper.GetRabbitMQConnection();

            _connection = _factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("AnswersQueue",true,false,false,null);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 3, global: false);

            _consumer = new EventingBasicConsumer(_channel);

            return base.StartAsync(cancellationToken);
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _consumer.Received += async (ReportMessageCommand, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        AnswerLogger.logger(message);
                        _channel.BasicAck(ea.DeliveryTag, false);
                    };
                    _channel.BasicConsume(queue: "AnswersQueue", autoAck: false, consumer: _consumer);
                    await Task.Delay(1000, stoppingToken);

                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
