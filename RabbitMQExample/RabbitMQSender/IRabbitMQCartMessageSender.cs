
namespace RabbitMQExample.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
