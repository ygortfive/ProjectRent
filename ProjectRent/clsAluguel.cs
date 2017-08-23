using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRent
{
    class clsAluguel
    {
        string _nome, _rg, _cpf, _cel, _tel, _email, _ref, _tipo, _num;           
        int _cod, _agua, _net, _eletricidade, _garagem;
        DateTime _vencimento = new DateTime();
        DateTime _dataFim = new DateTime();
        DateTime _dataInicio = new DateTime();
        double _valor;       
        
        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set { _dataInicio = value; }
        }
        public DateTime DataFim
        {
            get { return _dataFim; }
            set { _dataFim = value; }
        }

        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }  

        public DateTime Vencimento
        {
            get { return _vencimento; }
            set { _vencimento = value; }
        }

        public int Garagem
        {
            get { return _garagem; }
            set { _garagem = value; }
        }

        public int Eletricidade
        {
            get { return _eletricidade; }
            set { _eletricidade = value; }
        }

        public int Net
        {
            get { return _net; }
            set { _net = value; }
        }

        public int Agua
        {
            get { return _agua; }
            set { _agua = value; }
        }

        public int Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }      


        public string Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string Ref
        {
            get { return _ref; }
            set { _ref = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public string Cel
        {
            get { return _cel; }
            set { _cel = value; }
        }

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public void GravarBanco()
        {
            //Classe Builder mais rápida
            //O método Append junta/concatena as strings para gravar
            StringBuilder CommandGravar = new StringBuilder();

            //Comando SQL
            CommandGravar.Append("insert into tb_inquilinos values (default, ");
            CommandGravar.Append("'" + _nome + "',");
            CommandGravar.Append("'" + _rg + "',");
            CommandGravar.Append("'" + _cpf + "',");
            CommandGravar.Append("'" + _cel + "',");
            CommandGravar.Append("'" + _tel + "',");
            CommandGravar.Append("'" + _email + "',");
            CommandGravar.Append("'" + _ref + "',");
            CommandGravar.Append("'" + _tipo + "',");
            CommandGravar.Append("'" + _num + "',");
            CommandGravar.Append("'" + _dataInicio.Date.ToString("yyyy-MM-dd") + "',");
            CommandGravar.Append("'" + _dataFim.Date.ToString("yyyy-MM-dd") + "',");
            CommandGravar.Append(    _valor + ",");
            CommandGravar.Append("'" + _vencimento.Date + "',");
            CommandGravar.Append("'" + _agua + "',");
            CommandGravar.Append("'" + _net + "',");
            CommandGravar.Append("'" + _eletricidade + "',");
            CommandGravar.Append("'" + _garagem + "',");
            CommandGravar.Append("'1'");
            CommandGravar.Append(");");

            //Comando feito agora será enviado para classe que executará
            clsConexaoBanco objBancoDados = new clsConexaoBanco();
            objBancoDados.ExecutaComando(CommandGravar.ToString());

        }

        public void AlterarBanco()
        {
            StringBuilder CommandGravar = new StringBuilder();

            //Comando SQL
            CommandGravar.Append("update tb_inquilinos set ");
            CommandGravar.Append("vr_nome = '" + _nome + "',");
            CommandGravar.Append("vr_rg = '" + _rg + "',");
            CommandGravar.Append("vr_cpf = '" + _cpf + "',");
            CommandGravar.Append("vr_cel = '" + _cel + "',");
            CommandGravar.Append("vr_tel = '" + _tel + "',");
            CommandGravar.Append("vr_email = '" + _email + "',");
            CommandGravar.Append("vr_ref = '" + _ref + "',");
            CommandGravar.Append("vr_tipo = '" + _tipo + "',");
            CommandGravar.Append("vr_num = '" + _num + "',");
            CommandGravar.Append("vr_data_inicio = '" + _dataInicio.Date.ToString("yyyy-MM-dd") + "',");
            CommandGravar.Append("vr_data_fim = '" + _dataFim.Date.ToString("yyyy-MM-dd") + "',");
            CommandGravar.Append("db_valor = '" + _valor + "',");
            CommandGravar.Append("dt_vencimento = '" + _vencimento.Date.ToString("yyyy-MM-dd") + "',");
            CommandGravar.Append("in_agua = '" + _agua + "',");
            CommandGravar.Append("in_net = '" + _net + "',");
            CommandGravar.Append("in_eletricidade = '" + _eletricidade + "',");
            CommandGravar.Append("in_garagem = '" + _garagem + "',");
            CommandGravar.Append("in_ativo = '1'");
            CommandGravar.Append("where id_cod = '" + _cod + "' ");
            CommandGravar.Append(");");
        }


        
        
    }
}
