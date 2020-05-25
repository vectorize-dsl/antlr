using System;
using System.Collections.Generic;
using System.Text;

namespace Vectorize.Domain
{
    public interface IVecFunction
    {
        string Name { get; }
    }

    public interface ICallableVecFunction<TContext> : IVecFunction
    {
        IVecValue Call(IVecValue[] args, TContext context);
    }
}
