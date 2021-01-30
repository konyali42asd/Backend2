using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Spacitifition
{
    public interface ISpecifition<T>
    {
        Expression<Func<T,bool>> Critera { get; }
        List<Expression<Func<T,object>>> InCludes { get; }
    }
}
