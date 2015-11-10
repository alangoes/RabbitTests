using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitTestsTask {
	class NewTask {
		static void Main(string[] args) {
			var message = GetMessage(args);
			var body = Encoding.UTF8.GetBytes(message);

			var properties = channel.CreateBasicProperties();
			properties.DeliveryMode = 2;

			channel.BasicPublish("", "hello", properties, body);
		}
	}
}
