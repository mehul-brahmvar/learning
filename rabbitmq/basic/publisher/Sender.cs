using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publisher
{
    public class Sender
    {
        public Sender()
        {
            while (true)
            {
                var message = Console.ReadLine();

                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "messageQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty, routingKey: "messageQueue", basicProperties: null, body: body);

                Console.WriteLine($"Message sent {message}");
                
            }
        } 
    }
}
