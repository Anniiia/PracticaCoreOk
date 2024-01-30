using PracticaCoreOk.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCoreOk.Repositories
{
    public class RepositoryClientePedidods
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryClientePedidods() {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NETCORE;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

     

        public List<string> GetClientes()
        {

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_CLIENTES";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> clientes = new List<string>();
            while (this.reader.Read())
            {
                clientes.Add(this.reader["CodigoCliente"].ToString());

            }
            this.reader.Close();
            this.cn.Close();

            return clientes;
        }

        public Clientes GetResumenCliente(string nombreCliente)
        {

            this.com.Parameters.Clear();
            SqlParameter pamNombre = new SqlParameter("@idcliente", nombreCliente);
            this.com.Parameters.Add(pamNombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_CLIENTES_DATOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Clientes cliente = new Clientes();
            while (this.reader.Read())
            {
                string empresa = this.reader["EMPRESA"].ToString();
                cliente.Empresa = empresa;
                string contacto = this.reader["CONTACTO"].ToString();
                cliente.Contacto = contacto;
                string cargo = this.reader["CARGO"].ToString();
                cliente.Cargo = cargo;
                string ciudad = this.reader["CIUDAD"].ToString();
                cliente.Ciudad = ciudad;
                int telefono = int.Parse(this.reader["TELEFONO"].ToString());
                cliente.Telefono = telefono;
            }


            this.reader.Close();


            this.cn.Close();
            this.com.Parameters.Clear();

            return cliente;


        }

        public List<string> GetPedidos(string nombreCliente)
        {
          


            SqlParameter pamNombre = new SqlParameter("@idcliente", nombreCliente);
            this.com.Parameters.Add(pamNombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_PEDIDOS_CLIENTE";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Pedidos pedido = new Pedidos();

            List<string> pedidos = new List<string>();
            while (this.reader.Read())
            {
                pedidos.Add(this.reader["CODIGOPEDIDO"].ToString());

            }
            this.reader.Close();
            this.cn.Close();

            return pedidos;


        }

        public Pedidos GetResumenPedido(string nombrePedido)
        {
            this.com.Parameters.Clear();

            SqlParameter pamNombre = new SqlParameter("@idpedido", nombrePedido);
            this.com.Parameters.Add(pamNombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_PEDIDOS_DATOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
   
            Pedidos pedido = new Pedidos();
            while (this.reader.Read())
            {
                string codigoPedido = this.reader["CODIGOPEDIDO"].ToString();
                pedido.CodigoPedido = codigoPedido;
                string codigoCliente = this.reader["CODIGOCLIENTE"].ToString();
                pedido.CodigoCliente = codigoCliente;
                string fecha = this.reader["FECHAENTREGA"].ToString();
                pedido.FechaEntrega = fecha;
                string forma = this.reader["FORMAENVIO"].ToString();
                pedido.FormaEnvio = forma;
                int importe = int.Parse(this.reader["IMPORTE"].ToString());
                pedido.Importe = importe;
            }


            this.reader.Close();


            this.cn.Close();
            this.com.Parameters.Clear();

            return pedido;


        }

        public void Elminar(string nombrePedido) {
            SqlParameter pamNombre = new SqlParameter("@idcliente", nombrePedido);
            this.com.Parameters.Add(pamNombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_ELIMINAR";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
        }
    }
}
