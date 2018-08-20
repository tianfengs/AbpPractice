using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using StructureMap;

namespace LazyLoadingDemo.LazyLodingField
{
    [Serializable]
    public class LazyLoadStructureMapAspect:LocationInterceptionAspect
    {
        private object _backingField;
        readonly object _syncRoot=new object();
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            if (_backingField==null)
            {
                lock (_syncRoot)
                {
                    if (_backingField==null)
                    {
                        var locationType = args.Location.PropertyInfo.PropertyType;
                        _backingField= ObjectFactory.GetInstance(locationType);
                    }

                }
            }
            args.Value = _backingField;
        }
    }
}
