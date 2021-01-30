using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Spacitifition
{
    public class BaseISpecifition<T> : ISpecifition<T>
    {
        public BaseISpecifition(Expression<Func<T,bool>> criteria)
        {
            Critera = criteria;
        }
        public Expression<Func<T, bool>> Critera { get; }

        public List<Expression<Func<T, object>>> InCludes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            InCludes.Add(includeExpression);
        }
    }
}
