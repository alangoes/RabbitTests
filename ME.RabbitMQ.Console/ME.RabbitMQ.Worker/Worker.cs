using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using ME.Rabbit.Services.Implementation;
using ME.RabbitMQ.Commands;
using ME.RabbitMQ.Services;

namespace ME.RabbitMQ.Worker {
	class Worker {
		static void Main(string[] args) {
			Console.Write("Olá, meu nome é ME.RabbitMQ.Worker.\n");

			var messageBus = RabbitHutch.CreateBus("host=localhost");

			messageBus.Subscribe<CommandSubmeterDocumento>("CommandQueue", cmd => {
				Console.Write("Processando o comando via Subscribe Method...\n");

				IMotor _motorService = new Motor();
				string retStr = _motorService.SubmeterDocumento(cmd);

				Console.Write(retStr);
			});			

			messageBus.Receive<CommandText>("CommandQueue", cmd => {
				Console.Write("Processando o comando via Receive Method...\n");
				Console.WriteLine("Iniciando {0} ... \n", cmd.Text);

				string[] cmdParms = cmd.Text.Split('#');

				CommandSubmeterDocumento cmdSubmeterDocumento = new CommandSubmeterDocumento();
				cmdSubmeterDocumento.IDMain = Convert.ToInt32(cmdParms[1]);
				cmdSubmeterDocumento.ProcessoID = Convert.ToInt32(cmdParms[2]);
				cmdSubmeterDocumento.DocumentoID = Convert.ToInt32(cmdParms[3]);
				cmdSubmeterDocumento.Observacao = cmdParms[4];
				cmdSubmeterDocumento.IP = cmdParms[5];

				IMotor _motorService = new Motor();
				string retStr = _motorService.SubmeterDocumento(cmdSubmeterDocumento);

				Console.Write(retStr);
			});

			messageBus.Receive<CommandSubmeterDocumento>("CommandQueue", cmd => {
				Console.Write("Processando o comando via Receive com implementação igual do Subscribe...\n");
	
				IMotor _motorService = new Motor();
				string retStr = _motorService.SubmeterDocumento(cmd);

				Console.Write(retStr);
			});

			Console.Read();
		}
	}
}
