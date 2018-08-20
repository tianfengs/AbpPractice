using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CarRental.Core.Services.Common;

namespace CarRental.Core.Services
{
    public interface ITransactionManager2
    {
        void Wrapper(Action method);
    }

    public class TransactionManager2 : ITransactionManager2
    {
        public void Wrapper(Action method)
        {
            using (var ts=new TransactionScope())
            {
                var retires = 3;
                var succeeded = false;
                while (!succeeded)
                {
                    try
                    {
                        method();
                        ts.Complete();
                        succeeded = true;
                    }
                    catch (Exception ex)
                    {
                        if (retires >= 0)
                            retires--;
                        else
                        {
                            if (!ExceptionHelper.Handle(ex))
                                throw;
                        }
                    }
                }
            }
        }
    }

}
