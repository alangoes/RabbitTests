using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using ME.RabbitMQ.Commands;

namespace ME.RabbitMQ {
	class Program {
		static void Main(string[] args) {
			Console.Write("Olá, meu nome é ME.RabbitMQ.\n");

			using (var messageBus = RabbitHutch.CreateBus("host=localhost")) {
				Console.Write("Enviando o comando via Publish method.\n");

				CommandSubmeterDocumento command = new CommandSubmeterDocumento();
				command.IDMain = 21054;
				command.ProcessoID = 1;
				command.DocumentoID = 12098;
				command.Observacao = string.Empty;
				command.IP = "::1";

				messageBus.Publish<CommandSubmeterDocumento>(command);				
			}

			using (var messageBus = RabbitHutch.CreateBus("host=localhost")) {
				Console.Write("Enviando o comando via Send method.\n");

				messageBus.Send("CommandQueue", new CommandText { Text = "SUBMETERDOCUMENTO#21054#1#12098##::1" });				
			}

			using (var messageBus = RabbitHutch.CreateBus("host=localhost")) {
				Console.Write("Enviando o comando via Send com implementação igual ao Publish.\n");

				CommandSubmeterDocumento command = new CommandSubmeterDocumento();
				command.IDMain = 21054;
				command.ProcessoID = 1;
				command.DocumentoID = 12098;
				command.Observacao = string.Empty;
				command.IP = "::1";

				messageBus.Send("CommandQueue", command);
			}

			Console.Read();
		}
	}
}
