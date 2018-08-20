using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services
{
    public interface ITransactionFacade
    {
        void Wrapper(Action method);
    }

    public class TransactionFacade : ITransactionFacade
    {
        private readonly ITransactionManager _transactionManager;
        private readonly IExceptionHandler _exceptionHandler;

        public TransactionFacade(ITransactionManager transactionManager, IExceptionHandler exceptionHandler)
        {
            _transactionManager = transactionManager;
            _exceptionHandler = exceptionHandler;
        }

        public void Wrapper(Action method)
        {
            _exceptionHandler.Wrapper(()=>
                _transactionManager.Wrapper(method)
                );
        }
    }

}
