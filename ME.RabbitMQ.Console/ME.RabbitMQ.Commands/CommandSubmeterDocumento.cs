using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.RabbitMQ.Commands {
	public class CommandSubmeterDocumento {
		public int IDMain { get; set; }
		public int ProcessoID { get; set; }
		public int DocumentoID { get; set; }
		public string Observacao { get; set; }
		public string IP { get; set; }
	}
}
