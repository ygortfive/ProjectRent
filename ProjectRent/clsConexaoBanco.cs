using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjectRent
{
    class clsConexaoBanco
    {
        public static MySqlConnection AbreBanco()
        {
            string stringConexao = "server=localhost;database=bd_aluguel;uid=root;pwd=";

            try
            {
                MySqlConnection com = new MySqlConnection(stringConexao);
                com.Open();
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //====================================================================

        public void FechaBanco(MySqlConnection com)
        {
            try
            {
                if (com.State == ConnectionState.Open)
                {
                    com.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       //====================================================================

        public void ExecutaComando(string strCommand)
        {
            MySqlConnection com = AbreBanco();

            try
            {
                MySqlCommand sqlCommand = new MySqlCommand(strCommand, com);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FechaBanco(com);
            }
        }
        
    }
}
