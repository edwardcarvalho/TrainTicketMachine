using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrainTicketMachine.Service.Repository
{
    /// <summary>
    /// Interface that determines contracts to be implemented for the repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        ICollection<string> GetAll(string param);
    }
}