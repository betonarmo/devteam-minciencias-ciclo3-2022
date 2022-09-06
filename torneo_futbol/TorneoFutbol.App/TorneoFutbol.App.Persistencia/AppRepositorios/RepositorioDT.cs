using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {
        private readonly DataContext _dataContext = new DataContext();
        public DirectorTecnico AddDT(DirectorTecnico DT)
        {
            var DTInsertado = _dataContext.DirectoresTecnicos.Add(DT);
            _dataContext.SaveChanges();
            return DTInsertado.Entity;
        }
        public IEnumerable<DirectorTecnico> GetAllDTs()
        {
            return _dataContext.DirectoresTecnicos;
        }
    }
}