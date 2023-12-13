using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using var connection = await factory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync("hello-world", durable:false, exclusive:false, autoDelete:false, arguments:null);

var message = "Hello world";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(exchange:string.Empty, routingKey:"hello-world", body: body);