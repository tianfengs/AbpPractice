using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace LazyLoadingDemo
{
    [Serializable]
    public class MyLazyLoadingGetterAspect : LocationInterceptionAspect
    {
        private object _backingField;
        readonly object _syncRoot = new object();
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            if (_backingField == null)
            {
                lock (_syncRoot)
                {
                    if (_backingField == null)
                    {
                        args.ProceedGetValue();//继续像往常那样执行get
                        _backingField = args.Value;//将get获得的属性值保存到支持字段中
                    }
                }
            }
            args.Value = _backingField;//因为支持字段中已经有值了，直接赋值即可
        }
    }
}
