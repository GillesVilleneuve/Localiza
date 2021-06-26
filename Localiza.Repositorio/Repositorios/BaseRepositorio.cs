using Localiza.Dominio.Contratos;
using Localiza.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Localiza.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly LocalizaContexto LocalizaContexto; // protected disponibiliza para as classes filhas

        public BaseRepositorio(LocalizaContexto localizaContexto)
        {
            LocalizaContexto = localizaContexto;

        }
        public void Adicionar(TEntity entity)
        {
            LocalizaContexto.Set<TEntity>().Add(entity);
            LocalizaContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            LocalizaContexto.Set<TEntity>().Update(entity);
            LocalizaContexto.SaveChanges();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return LocalizaContexto.Set<TEntity>().ToList();
        }

        public TEntity OpterPorId(int id)
        {
            return LocalizaContexto.Set<TEntity>().Find(id);
        }

        public void Remover(TEntity entity)
        {
            LocalizaContexto.Remove(entity);
            LocalizaContexto.SaveChanges();
        }
        public void Dispose()
        {
            LocalizaContexto.Dispose(); //Descarta o BaseReposito (Obj de Contexto) da memória.
        }
    }
}
