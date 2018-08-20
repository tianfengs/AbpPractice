
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class TransactionManager:ITransactionManager
    {
        public void Wrapper(Action method)
        {
            using (var ts=new TransactionScope())
            {
                var retries = 3;
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
                        if (retries>=0)
                        {
                            retries--;
                        }
                        else
                        {
                            throw ex;
                        }
                    }

                }
            }
        }
    }
}
