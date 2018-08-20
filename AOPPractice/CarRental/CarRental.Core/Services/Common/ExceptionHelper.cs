using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Services.Common
{
    public class ExceptionHelper
    {
        public static bool Handle(Exception ex)
        {
            if (ex.GetType()==typeof(ArithmeticException))
            {
                return false;
            }
            if (ex.GetType()==typeof(TimeoutException))
            {
                return true;
            }

            //等等
            return false;
        }
    }
}
