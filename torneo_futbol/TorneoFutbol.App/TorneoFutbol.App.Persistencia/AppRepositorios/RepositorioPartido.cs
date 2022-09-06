using System;
using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext(); /// Se sumaron los parámetros
        public Partido AddPartido(Partido partido, int idLocal, int idVisitante)
        
        {
            //DateTime FechaHora = _dataContext.DateTime.Find(FechaHora);
            //Partido.FechaHora = FechaHora; 

            var equipoLocalEncontrado = _dataContext.Equipos.Find(idLocal);  
            partido.Local =  equipoLocalEncontrado;

            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idVisitante); 
            partido.Visitante = equipoVisitanteEncontrado;

            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }
       
        public IEnumerable<Partido> GetAllPartidos()
        {
            var partidos = _dataContext.Partidos
                .Include(e => e.Local)
                .Include(e => e.Visitante)
                .ToList();
            return partidos;
        }
    }
}