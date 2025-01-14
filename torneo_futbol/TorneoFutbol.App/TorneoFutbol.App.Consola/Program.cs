﻿using System.Text;
using Torneo.App.Dominio;
using System;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
            string str = "0";
            char chr;
            int opcion=0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Tecnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Posicion");
                Console.WriteLine("5. Insertar Jugador");
                Console.WriteLine("6. Insertar Partido");
                Console.WriteLine("7. Mostrar Municipios");
                Console.WriteLine("8. Mostrar DTs");
                Console.WriteLine("9. Mostrar Equipos");
                Console.WriteLine("A. Mostrar Posiciones");
                Console.WriteLine("B. Mostrar Jugadores");
                Console.WriteLine("C. Mostrar Partidos");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Digite opcion valida [0..9] o [A..B]");
                do {
                    str = Console.ReadLine();
                    opcion = (int) str[0];
                } while (!((opcion >= 48 && opcion<=57) || (opcion>=65 && opcion<=67)));
                if (opcion>=48 && opcion<=57){
                    opcion=opcion-48;
                }else{
                    if (opcion>=65 && opcion<=67){
                        opcion=opcion-65+10;
                    } else{
                        opcion=0;
                    }
                }
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
                        AddPosicion();
                        break;    
                    case 5:
                        AddJugador();
                        break;
                    case 6:
                        AddPartido();
                        break;    
                    case 7:
                        GetAllMunicipios();
                        break;    
                    case 8:
                        GetAllDTs();
                        break;
                    case 9:
                        GetAllEquipos();
                        break;
                    case 10:  
                        GetAllPosiciones();
                        break;    
                    case 11:
                        GetAllJugadores();
                        break;        
                    case 12:
                        GetAllPartidos();
                        break;    
                    default:
                        Console.WriteLine(" Digite opcion valida [0..9] o [A..B] ");
                        break;         
                }
                Console.WriteLine("Presione enter");
                chr = Console.ReadKey().KeyChar;        
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
            GetAllMunicipios();
            Console.WriteLine("Digite el iD del equipo municipio:");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            GetAllDTs();
            Console.WriteLine("Digite el iD de director técnico:");
            int idDT = Int32.Parse(Console.ReadLine());
            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void AddPosicion()
        {
            Console.WriteLine("Digite Posicion:");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }

        private static void AddJugador()
        {
            Console.WriteLine("Digite nombre del Jugador:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Digite Numero del Jugador :");
            int numero = Int32.Parse(Console.ReadLine());
            GetAllEquipos();
            Console.WriteLine("Digite el iD del Equipo:");
            int idEquipo = Int32.Parse(Console.ReadLine());
            GetAllPosiciones();
            Console.WriteLine("Digite el iD de la Posicion:");
            int idPosicion = Int32.Parse(Console.ReadLine());
            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
            };
            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }
        
        private static void AddPartido()
        {
            Console.WriteLine("Digite la fecha del partido (mm-dd-yyyy):");
            string fechaHora = (Console.ReadLine());
            DateTime myDate = DateTime.Parse(fechaHora);
            GetAllEquipos();
            Console.WriteLine("Escriba id del Equipo Local");
            int idLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el marcador del Equipo Local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());
            GetAllEquipos();
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

        private static void GetAllMunicipios()
        {
            Console.WriteLine("Municipios");
            Console.WriteLine("Id"+"\t"+"Nombre_Municipio");
            repetirChar('-',30);
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + "\t" + municipio.Nombre);
            }
        }

        private static void GetAllDTs()
        {
            Console.WriteLine("Directores Tecnicos");
	        Console.WriteLine("ID"+"\t"+"Nombre_DT"+"\t"+"Documento"+"\t"+"Telefono");
            repetirChar('-',50);
            foreach (var dt in _repoDT.GetAllDTs())
            {
                Console.WriteLine(dt.Id + "\t" + dt.Nombre +"\t"+dt.Documento + "\t" + dt.Telefono);
            }
        }

        private static void GetAllEquipos()
        {
            Console.WriteLine("Equipos");
            Console.WriteLine("ID"+"\t"+"Nombre_Equipo"+"\t"+"Municipio"+"\t"+"Director_Tecnico");
            repetirChar('-',62);
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + "\t" + equipo.Nombre 
                + "\t"+ equipo.Municipio.Nombre + "\t" + equipo.DirectorTecnico.Nombre);
            }
        }

        private static void GetAllPosiciones()
        {
            Console.WriteLine("Posiciones");
            Console.WriteLine("ID"+"\t"+"Posicion_terreno_de_Juego");
            repetirChar('-',30);
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + "\t" + posicion.Nombre);
            }
        }

        private static void GetAllJugadores()
        {
            Console.WriteLine("Jugadores");
            Console.WriteLine("ID"+"\t"+"Nombre_Jugador"+"\t"+"Numero"+"\t"+"Posicion"+"\t"+"Equipo");
            repetirChar('-',60);
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Id + "\t" + jugador.Nombre + "\t" +
                jugador.Numero+"\t"+ jugador.Posicion.Nombre + "\t" + jugador.Equipo.Nombre);
            }
        }

        private static void repetirChar(char car, int n){
            string str = string.Concat(Enumerable.Repeat(car, n));
            Console.WriteLine(str);
        }

       private static void GetAllPartidos()        
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