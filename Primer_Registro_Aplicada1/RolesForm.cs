using Primer_Registro_Aplicada1.BLL;
using Primer_Registro_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_Registro_Aplicada1
{
    public partial class RolesForm : Form
    {
        public RolesForm()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = String.Empty;
            FechaDateTimePicker.Value = DateTime.Now;
        }

        private Roles LLenaClase()
        {
            Roles roles = new Roles();

            roles.RolId = Convert.ToInt32(IdNumericUpDown.Value);
            roles.Descripcion = DescripcionTextBox.Text;
            roles.FechaDeCreacion = FechaDateTimePicker.Value;
            return roles;
        }

        private void LLenaCampo(Roles roles)
        {
            IdNumericUpDown.Value = roles.RolId;
            DescripcionTextBox.Text = roles.Descripcion;
            FechaDateTimePicker.Value = roles.FechaDeCreacion;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "El campo Descripcion no puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Roles rol = RolesBLL.Buscar((int)IdNumericUpDown.Value);
            return (rol != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Roles rol = new Roles();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            rol = RolesBLL.Buscar(id);

            if (rol != null)
                LLenaCampo(rol);
            else
                MessageBox.Show("Rol no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            if (RolesBLL.Buscar(id) != null)
            {
                if (RolesBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se puede eliminar un rol que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Roles roles;

            if (!Validar())
                return;
            roles = LLenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = RolesBLL.Guardar(roles);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un rol que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = RolesBLL.Modificar(roles);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
