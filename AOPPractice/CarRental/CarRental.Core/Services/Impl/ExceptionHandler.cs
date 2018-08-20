using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Services.Common;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class ExceptionHandler:IExceptionHandler
    {
        public void Wrapper(Action method)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                if (ExceptionHelper.Handle(ex))
                {
                    throw ex;
                }
                throw ex;
            }
        }
    }
}
