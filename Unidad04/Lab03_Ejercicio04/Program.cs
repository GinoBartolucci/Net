using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lab03_Ejercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind; User ID=sa;Pwd=123";

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("Listado de Empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }

            Console.Write("Escriba el CustomerID que desea modificar: ");
            string custid = Console.ReadLine();

            DataRow[] rwempresas = dtEmpresas.Select("CustomerID= '" + custid + "'");
            if(rwempresas.Length != 1)
            {
                Console.WriteLine("CustomerID no encontrado");
                Console.ReadLine();
                return;
            }
            else
            {
                DataRow rowMiEmpresa = rwempresas[0];
                string nombreactual = rowMiEmpresa["CompanyName"].ToString();
                Console.WriteLine("Nombre actual de la empresa: " + nombreactual);
                Console.Write("Escriba el nuevo nombre: ");
                string nuevonombre = Console.ReadLine();

                rowMiEmpresa.BeginEdit();
                rowMiEmpresa["CompanyName"] = nuevonombre;
                rowMiEmpresa.EndEdit();

                SqlCommand upcommand = new SqlCommand();
                upcommand.Connection = myconn;
                upcommand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";
                upcommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
                upcommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

                myadap.UpdateCommand = upcommand;
                myadap.Update(dtEmpresas);

            }


            Console.ReadLine();

        }
        private void Ejercicio_04_03()
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind; User ID=sa;Pwd=123";

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("Listado de Empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }

            Console.Write("Escriba el CustomerID que desea modificar: ");
            string custid = Console.ReadLine();

            DataRow[] rwempresas = dtEmpresas.Select("CustomerID= '" + custid + "'");
            if (rwempresas.Length != 1)
            {
                Console.WriteLine("CustomerID no encontrado");
                Console.ReadLine();
                return;
            }
            else
            {
                DataRow rowMiEmpresa = rwempresas[0];
                string nombreactual = rowMiEmpresa["CompanyName"].ToString();
                Console.WriteLine("Nombre actual de la empresa: " + nombreactual);
                Console.Write("Escriba el nuevo nombre: ");
                string nuevonombre = Console.ReadLine();

                rowMiEmpresa.BeginEdit();
                rowMiEmpresa["CompanyName"] = nuevonombre;
                rowMiEmpresa.EndEdit();

                SqlCommand upcommand = new SqlCommand();
                upcommand.Connection = myconn;
                upcommand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";
                upcommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
                upcommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

                myadap.UpdateCommand = upcommand;
                myadap.Update(dtEmpresas);

            }


            Console.ReadLine();

        }
        private void Ejercicio_04_02()
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind; User ID=sa;Pwd=123";

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("Listado de Empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }
            Console.ReadLine();

        }
        private void Ejercicio_04_01()
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind; User ID=sa;Pwd=123";

            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            mycommand.Connection = myconn;

            SqlDataAdapter myadap = new SqlDataAdapter(mycommand.CommandText, mycommand.Connection);

            myconn.Open();
            SqlDataReader mydr = mycommand.ExecuteReader();
            dtEmpresas.Load(mydr);
            myconn.Close();

            Console.WriteLine("Listado de Empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }
            Console.ReadLine();


        }
    }
}
