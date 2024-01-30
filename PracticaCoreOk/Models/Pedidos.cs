using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCoreOk.Models
{
    public class Pedidos
    {
        public string CodigoPedido { get; set; }
        public string CodigoCliente { get; set; }
        public string FechaEntrega { get; set; }
        public string FormaEnvio { get; set; }
        public int Importe { get; set; }

        public List<string> PedidosList { get; set; }

        public Pedidos()
        {
            this.PedidosList = new List<string>();
        }
    
}
}
