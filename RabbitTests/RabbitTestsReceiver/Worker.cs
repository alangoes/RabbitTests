using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using EasyNetQ;
using RabbitTestsCommon;
using ME.Services.MotorRegras3;
using ME.Services.MotorRegras3.Implementation;

namespace RabbitTestsReceiver {
	class Worker {
		public static void Main() {
			/*var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection()) {
				using (var channel = connection.CreateModel()) {
					channel.QueueDeclare("hello", false, false, false, null);

					var consumer = new QueueingBasicConsumer(channel);
					channel.BasicConsume("hello", true, consumer);

					Console.WriteLine(" [*] Waiting for messages." +
																	 "To exit press CTRL+C");
					while (true) {
						var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

						var body = ea.Body;
						var message = Encoding.UTF8.GetString(body);
						Console.WriteLine(" [x] Received {0}", message);
					}
				}
			}*/

		/*	var messageBus = RabbitHutch.CreateBus("host=localhost");
			messageBus.Receive<MyMessage>("CommandQueue", msg => {
				IMotorRegrasWorkflow3 motorV3Service = new MotorRegrasWorkflow3();
				motorV3Service.submeterDocumento(21054, 1, 12098, string.Empty, "::1");

				Console.WriteLine("Mandou");
			});*/



			var messageBus = RabbitHutch.CreateBus("host=localhost");

			messageBus.Subscribe<MyMessage>("mymessage", msg => {
				MyMessage myMessage = new MyMessage();
				myMessage.Text = "GAugauagu";
				Console.WriteLine(myMessage.Text);
			});		

/*			var messageBus = RabbitHutch.CreateBus("host=localhost");

			messageBus.Subscribe<MyMessage>("mymessage", msg => {
				IMotorRegrasWorkflow3 motorV3Service = new MotorRegrasWorkflow3();
				motorV3Service.submeterDocumento(21054, 1, 12098, string.Empty, "::1");

				Console.WriteLine("Mandou");
			});		*/

			Console.Read();
		}
	}
}
