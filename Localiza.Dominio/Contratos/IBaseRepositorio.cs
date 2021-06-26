using System;
using System.Collections.Generic;

namespace Localiza.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Remover(TEntity entity);
        void Atualizar(TEntity entity);

        TEntity OpterPorId(int id);
        IEnumerable<TEntity> ObterTodos();

    }
}
