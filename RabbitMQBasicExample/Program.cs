

using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory= new ConnectionFactory();
factory.Uri = new Uri("amqps://ajussjfj:BBaMFe0vG7foucTCjXK7ABkJUlME2JGj@sparrow.rmq.cloudamqp.com/ajussjfj");
//CloudAMQP sunucusu aracılığı ile oluşturulan url adresi

using (IConnection connection =  factory.CreateConnection())
using(IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("mesajKuyrugu", false, false, true);
    byte[] byteMessage = Encoding.UTF8.GetBytes("rabbitMq deneme mesajı");
    channel.BasicPublish(exchange: "", routingKey: "mesajKuyrugu", body: byteMessage);

}

//ConnenctionFactor sınıfı ile bağlantı adresini tanımlıyoruz.
//CreateConnection ile bağlantıyı sağlıyoruz.
//CreateModel ile kullanacağımız kuyruğu oluşturabilmek için kanal kuruyoruz.,
