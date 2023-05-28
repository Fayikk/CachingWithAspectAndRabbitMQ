using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQExample.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        public RabbitMQCartMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage Message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                Password = _password,
                UserName = _userName,
                VirtualHost = "/",
                //Port = 15672,
                
            };
            _connection = factory.CreateConnection();
            var deneme = _connection;
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            var json = JsonConvert.SerializeObject(Message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "",routingKey:queueName,basicProperties:null,body:body);
        }
    }
}
