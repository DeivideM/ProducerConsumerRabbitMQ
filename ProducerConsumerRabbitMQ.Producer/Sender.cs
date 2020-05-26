using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Channels;

namespace ProducerConsumerRabbitMQ.Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            //using
            //Erlang 23.0
            //RabbitMQ 3.8.4

            var factory = new ConnectionFactory() { HostName = "localhost" };
            string queue = "BasicTest";

            using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null); //Creating a queue

                string message = "Getting started with with .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", queue, null, body);
                Console.WriteLine($"Sent message {message}");
            }

            Console.Write("Press any key to exit the app...");
            Console.ReadLine();
        }
    }
}
