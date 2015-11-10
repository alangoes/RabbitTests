using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME.RabbitMQ.Commands;

namespace ME.RabbitMQ.Services {
	public interface IMotor {
		string SubmeterDocumento(CommandSubmeterDocumento cmd);
	}
}
