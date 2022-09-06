using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Tecnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Partido"); 
                //Console.WriteLine("4. Mostrar Municipios");
                //Console.WriteLine("5. Mostrar DTs");
                //Console.WriteLine("6. Mostrar Equipos");
                Console.WriteLine("8. Mostrar Partidos");
                Console.WriteLine("0. Salir");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        AddPartido();
                        break;
                    /*case 5:
                        GetAllMunicipios();
                        break;
                    case 6:
                        GetAllDTs();
                        break;
                    case 7:
                        GetAllEquipos();
                        break;*/
                    case 8:
                        GetAllPartidos();
                        break;


                }

            } while (opcion != 0);

        }
        private static void AddMunicipio()
        {
            Console.WriteLine("Digite Municipio:");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Digite nombre de director técnico:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Digite documento de director técnico:");
            string documento = Console.ReadLine();
            Console.WriteLine("Digite telefono de director técnico:");
            string telefono = Console.ReadLine();
            var DT = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(DT);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Digite nombre del equipo:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Digite el iD del equipo municipio:");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite el iD de director técnico:");
            int idDT = Int32.Parse(Console.ReadLine());
            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void AddPartido()
        {
            Console.WriteLine("Digite la fecha del partido (mm-dd-yyyy):");
            string fechaHora = (Console.ReadLine());
            DateTime myDate = DateTime.Parse(fechaHora);

            Console.WriteLine("Escriba id del Equipo Local");
            int idLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el marcador del Equipo Local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Escriba el id del Equipo Visitante");
            int idVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el marcador del equipo Visitante");
            int marcadorVisitante = Int32.Parse(Console.ReadLine());

            var partido = new Partido
            {

                FechaHora = myDate,
                MarcadorLocal = marcadorLocal,
                MarcadorVisitante = marcadorVisitante,

            };
            _repoPartido.AddPartido(partido, idLocal, idVisitante);
        }
        private static void GetAllPartidos()               ///Se añade GetAllPartidos()
        {
            foreach (var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine("Fecha: " + partido.FechaHora + "\n" 
                + "Partido ID: " + partido.Id + "\n" + "Nombre Equipo Local: " + partido.Local.Nombre 
                + "\n" + "Marcador local: " + partido.MarcadorLocal + "\n" 
                + "Nombre Equipo Visitante: " + partido.Visitante.Nombre + "\n"  
                + "Marcador Visitante: " + partido.MarcadorVisitante);
            } 
        }

    }
}