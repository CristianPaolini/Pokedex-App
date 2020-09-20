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
        public Pokedex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvLista.DataSource = negocio.listar();
            dgvLista.Columns[2].Visible = false;
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
    }
}
