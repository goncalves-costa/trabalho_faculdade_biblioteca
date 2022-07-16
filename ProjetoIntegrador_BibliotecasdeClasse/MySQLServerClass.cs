using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProjetoIntegrador_BibliotecasdeClasse
{
    public class MySQLServerClass
    {
        public string stringConn;
        public MySqlConnection conBD;


        public MySQLServerClass()
        {

            try
            {
                stringConn = "server=localhost;userid=root;password=3rAde@19UltroN14V1sao;database=biblioteca";
                conBD = new MySqlConnection(stringConn);
                conBD.Open();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new MySqlCommand(SQL, conBD);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public string SQLCommand(string SQL)
        {
            try
            {
                var myCommand = new MySqlCommand(SQL, conBD);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close()
        {
            conBD.Close();
        }

    }
}
