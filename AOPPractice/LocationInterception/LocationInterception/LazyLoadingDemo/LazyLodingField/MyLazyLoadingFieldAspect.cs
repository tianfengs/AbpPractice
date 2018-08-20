using System;
using PostSharp.Aspects;
using PostSharp.Reflection;
using PostSharp.Extensibility;

namespace LazyLoadingDemo.LazyLodingField
{
    [Serializable]
    public sealed class MyLazyLoadingFieldAspect : LocationInterceptionAspect
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
                        _backingField = Activator.CreateInstance(args.Location.LocationType);
                    }
                }
            }
            args.Value = _backingField;
        }

    }
}
