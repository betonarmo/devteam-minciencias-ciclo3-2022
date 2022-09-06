using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioDT
    {
        public DirectorTecnico AddDT(DirectorTecnico DT);
        public IEnumerable<DirectorTecnico> GetAllDTs();
    }
}