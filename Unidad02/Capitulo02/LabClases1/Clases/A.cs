using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class A
    {
        private string nombreInstancia;

        public A()
        {
            nombreInstancia = "Instancia sin nombre";
        }
        public A(string nombre)
        {
            nombreInstancia = nombre;
        }
        public void MostrarNombre()
        {
            Console.WriteLine(nombreInstancia);
        }
        protected void M1()
        {
            Console.WriteLine("El metodo 1 fue invocado");
        }
        public void M2()
        {
            Console.WriteLine("El metodo 2 fue invocado");
        }
        public void M3()
        {
            Console.WriteLine("El metodo 3 fue invocado");
        }

    }
}
