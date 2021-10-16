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

            rwAlumnos = dtAlumnos.NewRow();
            rwAlumnos[colApellido] = "Maradona";
            rwAlumnos[colNombre] = "Diego";
            dtAlumnos.Rows.Add(rwAlumnos);

            //Cursos

            DataTable dtCursos = new DataTable("Cursos");
            DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
            colIDCurso.ReadOnly = true;
            colIDCurso.AutoIncrement = true;
            colIDCurso.AutoIncrementSeed = 1;
            colIDCurso.AutoIncrementStep = 1;
            DataColumn colCurso = new DataColumn("Curso", typeof(String));
            dtCursos.Columns.Add(colIDCurso);
            dtCursos.Columns.Add(colCurso);
            dtCursos.PrimaryKey = new DataColumn[] { colIDCurso };

            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[colCurso] = "Informatica";
            dtCursos.Rows.Add(rwCurso);

            //Universidad

            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);

            //Relacion

            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn col_ac_IDAlumno = new DataColumn("IDAlumno", typeof(int));
            DataColumn col_ac_IDCurso = new DataColumn("IDcurso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(col_ac_IDCurso);
            dtAlumnos_Cursos.Columns.Add(col_ac_IDAlumno);

            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            //Relacion del dataSet
            DataRelation relAlumno_ac = new DataRelation("Alumno_Curso", colIDAlumno, col_ac_IDAlumno);
            DataRelation relCurso_ac = new DataRelation("Curso_Alumno", colIDCurso, col_ac_IDCurso);
          
            dsUniversidad.Relations.Add(relAlumno_ac);
            dsUniversidad.Relations.Add(relCurso_ac);

            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDAlumno] = 0;
            rwAlumnosCursos[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDAlumno] = 1;
            rwAlumnosCursos[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            Console.Write("Ingrese nombre del curso: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Listado de alimnos del curso " + materia);
            DataRow[] row_cursoInf = dtCursos.Select("Curso = '" + materia + "' ");
            foreach(DataRow rowCu in row_cursoInf)
            {
                DataRow[] row_AlumnosInf = rowCu.GetChildRows(relCurso_ac);
                foreach(DataRow rowAl in row_AlumnosInf)
                {
                    Console.WriteLine( rowAl.GetParentRow(relAlumno_ac)[colApellido].ToString() 
                        +", "+ rowAl.GetParentRow(relAlumno_ac)[colNombre].ToString());
                }
            }

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
