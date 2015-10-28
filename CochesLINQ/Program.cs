using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CochesLINQ.Clases;

namespace CochesLINQ
{
    class Program
    {
        public static List<Coche> coches = new List<Coche>();

        public static bool AddCoche(Coche c)
        {
            var q = coches.FirstOrDefault(o => o.Matricula == c.Matricula);

            if (q != null)
                throw new CocheMatriculaExistenteError(
                    $"La matricula {c.Matricula} ya existe en la lista, y pertenece al modelo {q.Modelo} fabricado en {q.AFabricacion}");

            coches.Add(c);
            return true;
        }


        static void Main(string[] args)
        {
            var c1 = new Coche("2204FGD", "Honda Civic", 2015);
            var c2 = new Coche("3455PHY", "Chevrolet Camaro", 1999);
            var c3 = new Coche("B343NSD", "Mini ONE", 2009);
            var c4 = new Coche("9485QWJ", "Renault Megane", 2011);
            var c5 = new Coche("2384PKN", "Hyundai Veloster", 2015);

            try
            {
                AddCoche(c1);
                AddCoche(c2);
                // AddCoche(c2);//fail
                AddCoche(c3);
                AddCoche(c4);
                AddCoche(c5);
            }
            catch (CocheMatriculaExistenteError e)
            {
                Console.WriteLine(e.Message);
            }

            var input = 6;

            do
            {
                Console.WriteLine("------------Menu------------");
                Console.WriteLine("1- Nuevo coche");
                Console.WriteLine("2- Listado de todos los coches");
                Console.WriteLine("3- Buscar por matrícula");
                Console.WriteLine("4- Buscar por modelo");
                Console.WriteLine("5- Buscar por modelo y año de fabricación");
                Console.WriteLine("6- Salir");
                Int32.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 2:
                        Console.WriteLine("/////////");
                        Console.WriteLine("Listado de coches: ");
                        if (coches.Count > 0)
                        {
                            foreach (var e in coches)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay vehiculos para mostrar");
                        }

                        Console.WriteLine("---------");
                        break;
                    case 3:
                        Console.WriteLine("/////////");
                        Console.WriteLine("Introduce la matrícula a buscar: ");
                        var ma = Console.ReadLine();
                        var resMa = coches.FirstOrDefault(o => o.Matricula == ma);

                        if (resMa == null)
                            Console.WriteLine($"No se ha encontrado ningun registro para la matricula {ma}");
                        else
                        {
                            Console.WriteLine($"Modelo: {resMa.Modelo} \nAño de fabricación: {resMa.AFabricacion}");
                        }

                        break;
                    case 4:
                        Console.WriteLine("/////////");
                        Console.WriteLine("Introduce el modelo a buscar: ");
                        var mo = Console.ReadLine();
                        var resMo = coches.Where(o => o.Modelo == mo).OrderBy(o => o.AFabricacion);

                        if (resMo.Any())
                        {
                            foreach (var c in resMo)
                            {
                                Console.WriteLine("---");
                                Console.WriteLine($"Matricula: {c.Matricula} \nAño de fabricación: {c.AFabricacion}");
                                Console.WriteLine("---");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No se ha encontrado ningun registro para el modelo {mo}");
                        }

                        break;

                    case 5:
                        Console.WriteLine("/////////");
                        Console.WriteLine("Introduce el modelo a buscar: ");
                        var mod = Console.ReadLine();
                        Console.WriteLine("Introduce la fecha de fabricación a buscar: ");
                        int fech;
                        Int32.TryParse(Console.ReadLine(), out fech);
                        var resmf = coches.Where(o => o.Modelo == mod && o.AFabricacion == fech).OrderByDescending(o=> o.Matricula);

                        if (resmf.Any())
                        {
                            foreach (var c in resmf)
                            {
                                Console.WriteLine("---");
                                Console.WriteLine($"Matricula: {c.Matricula}  \nModelo: {c.Modelo} \nAño de fabricación: {c.AFabricacion}");
                                Console.WriteLine("---");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No se ha encontrado ningun registro para el modelo {mod} y año {fech}");
                        }
                        break;
                }


            } while (input != 6);


        }
    }
}
