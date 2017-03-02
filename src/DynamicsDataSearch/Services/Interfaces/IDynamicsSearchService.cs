using DynamicsDataSearch.Models;
using System.Collections.Generic;

namespace DynamicsDataSearch.Services
{
    public interface IDynamicsSearchService
    {
        string GetJsonById(DynamicsSearch searchParams);
        TEntity GetById<TEntity>(DynamicsSearch searchParams);
        List<TEntity> Search<TEntity>(DynamicsSearch searchParams);
        string Search(DynamicsSearch searchParams);
    }
}
