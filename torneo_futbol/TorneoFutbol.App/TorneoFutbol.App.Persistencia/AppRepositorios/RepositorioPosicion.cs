using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPosicion : IRepositorioPosicion
    {
        private readonly DataContext _dataContext = new DataContext();
        public Posicion AddPosicion(Posicion posicion)
        {
            var posicionInsertado = _dataContext.Posicions.Add(posicion); 
            _dataContext.SaveChanges();
            return posicionInsertado.Entity;
        }
    }
}