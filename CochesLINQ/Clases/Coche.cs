using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CochesLINQ.Clases
{
    public class Coche
    {
        public override string ToString()
        {
            return $"\nMatricula -> {Matricula}\nModelo -> {Modelo}\nAño de fabricación -> {AñoFabricacion}";
        }

        public Coche(string matricula, string modelo, int añoFabricacion)
        {
            Matricula = matricula;
            Modelo = modelo;
            AñoFabricacion = añoFabricacion;
        }

        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public int AñoFabricacion { get; set; }
    }
}
