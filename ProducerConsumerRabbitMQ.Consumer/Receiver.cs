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
                    var body = ea.Body; 
                    var message = Encoding.UTF8.GetString(body.Span); //Please check if you can use only body. For this new RabbitMQ version it was required to use body.Span
                    Console.WriteLine($"Received message {message}");

                    /*
                    cannot convert from 'system.readonlymemory byte' to 'byte'
                    Workaround
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    Better Solution
                    var body = ea.Body; //ea.Body is of Type ReadOnlyMemory<byte>
                    var message = Encoding.UTF8.GetString(body.Span);
                    */

                };

                channel.BasicConsume(queue, true, consumer);

                Console.Write("Press any key to exit the app...");
                Console.ReadLine();
            }
        }
    }
}
