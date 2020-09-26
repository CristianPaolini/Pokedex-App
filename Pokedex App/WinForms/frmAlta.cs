using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WinForms
{
    public partial class frmAlta : Form
    {
        private Pokemon pokemon = null;
        public frmAlta()
        {
            InitializeComponent();
        }
        public frmAlta(Pokemon poke)
        {
            InitializeComponent();
            pokemon = poke;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Validacion val = new Validacion();
            bool[] comprobacion = val.validacionesfrmAlta(txtNombre.Text, txtDescripcion.Text, txtUrlImage.Text, cboTipo.SelectedIndex);
            if(comprobacion[0] && comprobacion[1] && comprobacion[2] && comprobacion[3])
            {

            
            if (pokemon == null)
                pokemon = new Pokemon();

            pokemon.Nombre = txtNombre.Text;
            pokemon.Descripcion = txtDescripcion.Text;
            pokemon.UrlImage = txtUrlImage.Text;
            pokemon.Tipo = (Tipo)cboTipo.SelectedItem;

            if (pokemon.Id == 0)
                negocio.agregar(pokemon);
            else
                negocio.modificar(pokemon);



            MessageBox.Show("Operación efectuada exitosamente", "Exito");
            Close();
            }

            else
            {
                if (!comprobacion[0]) txtNombre.BackColor = Color.Red;
                if (!comprobacion[1]) txtDescripcion.BackColor = Color.Red;
                if (!comprobacion[2]) txtUrlImage.BackColor = Color.Red;
                if (!comprobacion[3]) cboTipo.BackColor = Color.Red;
                MessageBox.Show("Campos faltantes", "Error en la carga");
            }
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            TipoNegocio tipoNegocio = new TipoNegocio();

            cboTipo.DataSource = tipoNegocio.listar();
            cboTipo.ValueMember = "Id";
            cboTipo.DisplayMember = "Descripcion";

            cboTipo.SelectedIndex = -1;

            if(pokemon != null)
            {
                txtNombre.Text = pokemon.Nombre;
                txtDescripcion.Text = pokemon.Descripcion;
                txtUrlImage.Text = pokemon.UrlImage;
                cboTipo.SelectedValue = pokemon.Tipo.Id;

                Text = "Modificación Pokemon";
            }
        }
    }
}
