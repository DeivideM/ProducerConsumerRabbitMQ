using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ProducerConsumerRabbitMQ.Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            string queue = "BasicTest";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.Span;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Received message {message}");
                };

                channel.BasicConsume(queue, true, consumer);

                Console.Write("Press any key to exit the app...");
                Console.ReadLine();
            }
        }
    }
}
