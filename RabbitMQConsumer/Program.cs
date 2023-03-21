using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://ajussjfj:BBaMFe0vG7foucTCjXK7ABkJUlME2JGj@sparrow.rmq.cloudamqp.com/ajussjfj");


using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("mesajKuyrugu", false, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("mesajKuyrugu", false, consumer);
    consumer.Received += (sender, e) =>
    {
        //e.Body : Kuyruktaki mesajı verir.
        Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
    };
}
Console.Read();