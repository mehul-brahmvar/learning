using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    public class Chef
    {
        public Chef()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "order_queue",
                     durable: true, // retain messages even rabbitmq is crashed
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false); //don't send more than one message to chef, let the first one finish.

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
              {
                  byte[] body = ea.Body.ToArray();
                  var message = Encoding.UTF8.GetString(body);
                  Console.WriteLine($"Received order: {message}");

                  // here channel could also be accessed as ((EventingBasicConsumer)sender).Model
                  channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
              };

            channel.BasicConsume(queue: "order_queue",
                     autoAck: false,
                     consumer: consumer);

            Console.ReadLine();
        }
    }
}
