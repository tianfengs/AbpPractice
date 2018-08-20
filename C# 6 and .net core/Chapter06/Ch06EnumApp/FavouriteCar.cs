using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06EnumApp
{
    [System.Flags]
    public enum FavouriteCar:byte
    {
        None=0,
        QiYa=1,
        DaZhong=1<<1,
        Bmw=1<<2,
        Benz=1<<3,
        FeryyLi=1<<4
    }
}
