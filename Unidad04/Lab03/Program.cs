using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataTable dtAlumnos = new DataTable();

            DataColumn colIDAlumno = new DataColumn("Key", typeof(int));
            colIDAlumno.ReadOnly = true;//solo lectura
            //el valor se auto incrementa empezando en 0 y sumando 1
            colIDAlumno.AutoIncrement = true;
            colIDAlumno.AutoIncrementSeed = 0;
            colIDAlumno.AutoIncrementStep = 1;

            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.Columns.Add(colIDAlumno);//se añade a la tabla
            dtAlumnos.PrimaryKey = new DataColumn[] { colIDAlumno };

            DataRow rwAlumnos = dtAlumnos.NewRow();
            rwAlumnos[colApellido] = "Messi";
            rwAlumnos[colNombre] = "Leo";
            dtAlumnos.Rows.Add(rwAlumnos);

            DataRow rwAlumnos2 = dtAlumnos.NewRow();
            rwAlumnos2[colApellido] = "Maradona";
            rwAlumnos2[colNombre] = "Diego";
            dtAlumnos.Rows.Add(rwAlumnos2);

            Console.ReadKey();
        }
        private void PrimeraparteDelLab()
        {
            //Crea una tabla
            DataTable dtAlumnos = new DataTable();

            //Crea columnas de la tabla
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            //Añade las columna a la tabla
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);
            //Crea un objeto fila de esa tabla (se crea despues de añadir las columnas)
            DataRow rwAlumnos = dtAlumnos.NewRow();
            //Asigna un valor a cada columna del objeto fila de la tabla.
            rwAlumnos[colApellido] = "Messi";
            rwAlumnos[colNombre] = "Leo";
            //Añade el objeto fila con los datos de messi a la tabla
            dtAlumnos.Rows.Add(rwAlumnos);

            DataRow rwAlumnos2 = dtAlumnos.NewRow();
            rwAlumnos2[colApellido] = "Maradona";
            rwAlumnos2[colNombre] = "Diego";
            dtAlumnos.Rows.Add(rwAlumnos2);

            /*
            Console.WriteLine("Listado de alumnos: ");
            foreach(DataRow row in dtAlumnos.Rows)
            {
                Console.WriteLine("\t Apellido: " + row[colApellido].ToString() +
                    "\n \t Nombre: "+row[colNombre].ToString()+"\n");
            }
            */

            Console.ReadKey();
        }
    }
}
