using System;
using System.Linq.Expressions;

namespace Domion.Abstractions
{
    public interface IQuerySpec<T> where T : class
    {
        Expression<Func<T, bool>> WhereExpression { get; }
    }
}