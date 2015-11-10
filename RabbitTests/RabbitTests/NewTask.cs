using System;
using System.Text;
using RabbitMQ.Client;
using EasyNetQ;
using RabbitTestsCommon;

namespace RabbitTestsSender {
	class NewTask {
		static void Main(string[] args) {
			/*var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection()) {
				using (var channel = connection.CreateModel()) {
					channel.QueueDeclare("hello", false, false, false, null);

					string message = "Hello World!";
					var body = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish("", "hello", null, body);
					Console.WriteLine(" [x] Sent {0}", message);
				}
			}*/

			/*var messageBus = RabbitHutch.CreateBus("host=localhost");
			var message = new MyMessage { Text = "Hello Rabbit" };
			messageBus.Send<MyMessage>("my.queue", message);*/

			/*using (var messageBus = RabbitHutch.CreateBus("host=localhost")) {
				MyMessage message = new MyMessage();
				messageBus.Publish<MyMessage>(message);
			}*/

			using (var messageBus = RabbitHutch.CreateBus("host=localhost")) {
				var message = new MyMessage { Text = "SUBMETERDOCUMENTO#21054#1#12098##::1" };
				messageBus.Send<MyMessage>("CommandQueue", message);
			}
		}
	}
}
