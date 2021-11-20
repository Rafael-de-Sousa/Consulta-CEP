using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaCEPs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCEP.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtRua.Clear();
        }

        private void btnConsultarCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text)) //teste para verificar se o campo txtCEP não está vazio; simbolo de exclamação nega a afirmação;
            {
                using (var ws = new WSCorreios.AtendeClienteClient()) //referenciando o WSCorreios
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtCEP.Text.Trim()); //Trim remove os espaços em branco antes ou no fim do txt;
                                                                           //variável endereço faz uma consulta ao método consultaCEP() da 
                                                                           //variável ws(web service) passando como parametro o campo txtCEP
                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
