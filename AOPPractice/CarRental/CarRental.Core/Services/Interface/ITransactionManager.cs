﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Services.Interface
{
    public interface ITransactionManager
    {
        void Wrapper(Action method);
    }
}
