using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Aplicacion.Modulo_Usuarios;
using SM.LibreriaComun.DTO;  


namespace WindowsFormsApplicationSimus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioLogica objUsuario = new UsuarioLogica();
            try
            {
                List<UsuarioDTO> list = new List<UsuarioDTO>();
                list = objUsuario.GetUsuarios();
            }
            catch (Exception ex)
            { label1.Text = ex.Message.ToString(); }
        }
    }
}
