using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME.RabbitMQ.Commands;
using ME.RabbitMQ.Services;

namespace ME.Rabbit.Services.Implementation {
	public class Motor : IMotor {
		public string SubmeterDocumento(CommandSubmeterDocumento cmd) {
			string strCommand = string.Format("O comando é o: SUBMETERDOCUMENTO#{0}#{1}#{2}#{3}#{4}\n", cmd.IDMain, cmd.ProcessoID, cmd.DocumentoID, cmd.Observacao, cmd.IP);

			return strCommand;
		}
	}
}
