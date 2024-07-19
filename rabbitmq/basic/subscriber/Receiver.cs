using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    public class Receiver
    {
        public Receiver()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "messageQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine("Waiting for message");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.Write($"Message received: {message}");
                Console.WriteLine();
            };

            channel.BasicConsume(queue: "messageQueue", autoAck: true, consumer: consumer);
            Console.ReadLine();
        }
    }
}
