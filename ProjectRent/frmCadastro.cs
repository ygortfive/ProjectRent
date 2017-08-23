using System;
using System.Windows.Forms;
using System.Globalization;

namespace ProjectRent
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();            
        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            //Teste para o migo ver o github :DDD
            //Validar campos em branco
            //Retirando as máscaras dos campos para fazer validação
            mtxDateVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxDateInicio.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxDateFim.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if((txtNome.Text == "") || (mxtCPF.Text == "") || (txtCel.Text == "") || (cboxTipo.Text == "") || (!MtxValor.MaskCompleted)
                || (mtxDateVencimento.Text == "") || (mtxDateInicio.Text == "") || (mtxDateFim.Text == ""))
            {
                MessageBox.Show("Os campos com * são obrigatório" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else
            {                
                //Retornando a mascara para ser compativel com o datetime
                mtxDateVencimento.TextMaskFormat = MaskFormat.IncludeLiterals;
                mtxDateInicio.TextMaskFormat = MaskFormat.IncludeLiterals;
                mtxDateFim.TextMaskFormat = MaskFormat.IncludeLiterals;
                //txtValor.TextMaskFormat = MaskFormat.IncludePrompt;                
                clsAluguel Aluguel = new clsAluguel();
                //Aluguel.Cod = int.Parse((txtCod.Text));
                Aluguel.Nome = txtNome.Text;
                Aluguel.Rg = txtRG.Text;
                Aluguel.Cpf = mxtCPF.Text;
                Aluguel.Cel = txtCel.Text;
                Aluguel.Tel = txtTel.Text;
                Aluguel.Ref = txtRef.Text;
                Aluguel.Email = txtEmail.Text;
                Aluguel.Tipo = cboxTipo.Text;
                Aluguel.Num = String.Format("{0:(###) #####-####}", txtNumLocal.Text);
                Aluguel.DataInicio = DateTime.Parse(mtxDateInicio.Text).Date;
                Aluguel.DataFim = DateTime.Parse(mtxDateFim.Text).Date;                
                Aluguel.Valor = Convert.ToDouble(String.Format(CultureInfo.InvariantCulture, "{0:000.00}", MtxValor.Text));
                Aluguel.Vencimento = DateTime.Parse(mtxDateVencimento.Text).Date;
                if (checkAgua.Checked)
                {
                    Aluguel.Agua = 1;
                }
                else
                {
                    Aluguel.Agua = 0;
                }
                if(checkEletricidade.Checked)
                {
                    Aluguel.Eletricidade = 1;
                }
                else
                {
                    Aluguel.Eletricidade = 0;
                }
                if (checkGaragem.Checked)
                {
                    Aluguel.Garagem = 1;
                }
                else
                {
                    Aluguel.Garagem = 0;
                }
                if (checkInternet.Checked)
                {
                    Aluguel.Net = 1;
                }
                else
                {
                    Aluguel.Net = 0;
                }
                
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

                
    }
}
