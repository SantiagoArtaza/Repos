using Back.Dominio;
using Final.Http;
using Newtonsoft.Json;

namespace Final
{
    public partial class Form1 : Form
    {
        Turno nuevo;
        public Form1()
        {
            InitializeComponent();
            nuevo = new Turno();
        }


        private async void CargarCombo()
        {
            string url = "https://localhost:7057/medicos";
            var result = await ClienteSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Medico>>(result);
            cboMedicos.DataSource = lst;
            cboMedicos.DisplayMember = "nombre";
            cboMedicos.ValueMember = "matricula";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            CargarCombo();
            dtpFecha.Value = DateTime.Now.AddDays(1);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if (validar())
            {
                Medico m = (Medico)cboMedicos.SelectedItem;
            string motivo = Convert.ToString(txtMotivoconsulta.Text);
            string fecha = dtpFecha.Value.ToString();
            string hora = txtHora.Text;

            DetalleTurno detalle = new DetalleTurno(m, motivo, fecha, hora);
            nuevo.AgregarDetalle(detalle);
            dgvTurnos.Rows.Add(new object[] { m.Matricula, m.Nombre, motivo, fecha, hora, "Quitar" });




        }
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTurnos.CurrentCell.ColumnIndex == 5)
            {
                nuevo.QuitarDetalle(dgvTurnos.CurrentRow.Index);
                dgvTurnos.Rows.RemoveAt(dgvTurnos.CurrentRow.Index);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            nuevo.Paciente = txtPaciente.Text;

            string bodyContent = JsonConvert.SerializeObject(nuevo);
            string url = "https://localhost:7057/turnos";
            var result = await ClienteSingleton.GetInstance().PostAsync(url, bodyContent);

            if (result.Equals("true"))
            {
                MessageBox.Show("Se registro el turno con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se puedo registrar el turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        private bool validar()
        {


            if (txtPaciente.Text == "")
            {
                MessageBox.Show("Ingrese un Paciente");

                return false;
            }

            if (cboMedicos.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese un medico");
                return false;
            }
            if (txtMotivoconsulta.Text == "")
            {
                MessageBox.Show("Ingrese un Motivo");

                return false;
            }
            if (txtHora.Text == "")
            {
                MessageBox.Show("Ingrese una hora");
                return false;
            }
            foreach (DataGridViewRow fila in dgvTurnos.Rows)
            {
                if (fila.Cells["cMedico"].Value.ToString().Equals(cboMedicos.Text))
                {
                    MessageBox.Show("El Turno ya esta cargado...."
                  , "Control"
                  , MessageBoxButtons.OK
                  , MessageBoxIcon.Exclamation);
                    return false;
                }
            }
             



            return true;




        }


        //public async bool Existe()
        //{
        //    string url = "https://localhost:7057/ConsultaExistente";
        //    var result = await ClienteSingleton.GetInstance().GetAsync(url);
        //    var lst = JsonConvert.DeserializeObject<List<Medico>>(result);
        //}

    }
}