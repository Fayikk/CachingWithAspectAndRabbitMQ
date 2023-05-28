namespace RabbitMQExample.Aspects.Autofac.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); //Generic versiyon 
        object Get(string key); //Generic olmayan versiyon.Ancak tip dönüşümü yapmamız gerekmektedir.
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //Cash'te varmı kontrolü sağlar.
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
