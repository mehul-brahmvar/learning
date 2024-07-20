using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSender
{
    public class Order
    {
        public Order()
        {
            while (true)
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "order_queue",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

                var message = Console.ReadLine();

                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "order_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine($"Sent {message}");
            }
        }
    }
}
