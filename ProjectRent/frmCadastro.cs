using System;
using System.Windows.Forms;

namespace ProjectRent
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();            
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar campos em branco
            dateVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            dateInicio.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            dateFim.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if((txtNome.Text == "") || (txtCPF.Text == "") || (txtCel.Text == "") || (cboxTipo.Text == "") || (double.Parse(txtValor.Text) == 0.0)
                || (dateVencimento.Text == "") || (dateInicio.Text == "") || (dateFim.Text == ""))
            {
                MessageBox.Show("Os campos com * são obrigatório" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else
            {
                dateVencimento.TextMaskFormat = MaskFormat.IncludeLiterals;
                dateInicio.TextMaskFormat = MaskFormat.IncludeLiterals;
                dateFim.TextMaskFormat = MaskFormat.IncludeLiterals;
                clsAluguel Aluguel = new clsAluguel();
                //Aluguel.Cod = int.Parse((txtCod.Text));
                Aluguel.Nome = txtNome.Text;
                Aluguel.Rg = txtRG.Text;
                Aluguel.Cpf = txtCPF.Text;
                Aluguel.Cel = txtCel.Text;
                Aluguel.Email = txtEmail.Text;
                Aluguel.Tipo = cboxTipo.Text;
                Aluguel.Num = txtNumLocal.Text;
                Aluguel.DataInicio = DateTime.Parse(dateInicio.Text).Date;
                Aluguel.DataFim = DateTime.Parse(dateFim.Text).Date;
                Aluguel.Valor = double.Parse(txtValor.Text);
                Aluguel.Vencimento = DateTime.Parse(dateVencimento.Text).Date;
                /*
                Aluguel.Agua = int.Parse(checkAgua.Text);
                Aluguel.Eletricidade = int.Parse(checkEletricidade.Text);
                Aluguel.Net = int.Parse(checkInternet.Text);
                Aluguel.Garagem = int.Parse(checkGaragem.Text);
                 */

                if (txtCod.Text == "") //NOVO
                {
                    Aluguel.GravarBanco();
                    MessageBox.Show("Inquilino registrado com sucesso." , "Novo inquilino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCod.Text != "") //Alterar
                {
                    Aluguel.AlterarBanco();
                    MessageBox.Show("Dados do inquilino alterados com sucesso.", "Alteração de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Close();
            }
        }

        private void checkAgua_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkAgua.Checked)
            {
                checkAgua.Text = "0";
            }
            else
            {
                checkAgua.Text = "1";
            }
        }

        private void checkEletricidade_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEletricidade.Checked)
            {
                checkEletricidade.Text = "0";
            }
            else
            {
                checkEletricidade.Text = "1";
            }
        }

        private void checkInternet_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkInternet.Checked)
            {
                checkInternet.Text = "0";
            }
            else
            {
                checkInternet.Text = "1";
            }
        }

        private void checkGaragem_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkGaragem.Checked)
            {
                checkGaragem.Text = "0";
            }
            else
            {
                checkGaragem.Text = "1";
            }
        }
    }
}
