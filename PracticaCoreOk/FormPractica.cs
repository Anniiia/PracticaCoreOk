using PracticaCoreOk.Models;
using PracticaCoreOk.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



#region PROCEDIMIENTOS ALMACENADOS

//create procedure SP_CLIENTES
//as
// Select * from clientes
//go


#endregion

namespace PracticaCoreOk
{
    public partial class FormPractica : Form
    {
        RepositoryClientePedidods repo;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryClientePedidods();
            this.loadClientes();
        }

        private void loadClientes()
        {

            List<string> clientes = this.repo.GetClientes();

            foreach (string data in clientes)
            {
                this.cmbclientes.Items.Add(data);
            }

        }

        private void LoadPedidos() {

            string nombre = this.cmbclientes.SelectedItem.ToString();
            List<string> pedidos = this.repo.GetPedidos(nombre);

            foreach (string data in pedidos)
            {
                this.lstpedidos.Items.Add(data);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            string nombre = this.cmbclientes.SelectedItem.ToString();

            Clientes cliente = this.repo.GetResumenCliente(nombre);

            this.txtempresa.Text = "";
            this.txtcontacto.Text = "";
            this.txtcargo.Text = "";
            this.txtciudad.Text = "";
            this.txttelefono.Text = "";

            this.txtempresa.Text = cliente.Empresa.ToString();
            this.txtcontacto.Text = cliente.Contacto.ToString();
            this.txtcargo.Text = cliente.Cargo.ToString();
            this.txtciudad.Text = cliente.Ciudad.ToString();
            this.txttelefono.Text = cliente.Telefono.ToString();

            this.LoadPedidos();
           

        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.lstpedidos.SelectedItem.ToString();



            Pedidos pedido = this.repo.GetResumenPedido(nombre);

            this.txtcodigopedido.Text = "";
            this.txtfechaentrega.Text = "";
            this.txtformaenvio.Text = "";
            this.txtimporte.Text = "";

            this.txtcodigopedido.Text = pedido.CodigoCliente.ToString();
            this.txtfechaentrega.Text = pedido.FechaEntrega.ToString();
            this.txtformaenvio.Text = pedido.FormaEnvio.ToString();
            this.txtimporte.Text = pedido.Importe.ToString();

 

        }
    }
}
