using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace WinForms
{
    public partial class Pokedex : Form
    {
        private List<Pokemon> listaOriginal;
        public Pokedex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaOriginal = negocio.listar();
            dgvLista.DataSource = listaOriginal;
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[3].Visible = false;

        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Pokemon poke = (Pokemon)dgvLista.CurrentRow.DataBoundItem;
                pbPokemon.Load(poke.UrlImage);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlta alta = new frmAlta();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon poke;
            poke = (Pokemon)dgvLista.CurrentRow.DataBoundItem;
            frmAlta modificar = new frmAlta(poke);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            negocio.eliminar(((Pokemon)dgvLista.CurrentRow.DataBoundItem).Id);
            cargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Pokemon> listafiltrada = listaOriginal.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvLista.DataSource = listafiltrada;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if(txtFiltro.Text == "")
            {
                dgvLista.DataSource = listaOriginal;
            }

            else
            {
                List<Pokemon> listaFiltrada = listaOriginal.FindAll(poke => poke.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || poke.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));

                dgvLista.DataSource = listaFiltrada;
            }
        }
    }
}
