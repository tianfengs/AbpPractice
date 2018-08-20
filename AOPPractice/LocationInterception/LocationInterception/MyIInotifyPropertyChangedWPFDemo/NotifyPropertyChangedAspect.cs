using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace MyIInotifyPropertyChangedWPFDemo
{
    [Serializable]
    public class NotifyPropertyChangedAspect:LocationInterceptionAspect
    {
        private string[] _derivedProperties;
        public NotifyPropertyChangedAspect(params string[] derived)//构造函数参数为可变长参数，用于接收导出属性
        {
            _derivedProperties = derived;
        }
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            var oldValue = args.GetCurrentValue();
            var newValue = args.Value;
            if (oldValue!=newValue)
            {
                args.ProceedSetValue();
                RaisePropertyChanged(args.Instance, args.LocationName);//只要属性执行了setter，就触发RaisePropertyChanged事件
                if (_derivedProperties!=null)
                {
                    //对每个导出属性触发事件
                    foreach (string derivedProperty in _derivedProperties)
                    {
                        RaisePropertyChanged(args.Instance,derivedProperty);
                    }
                }
            }
        }

        private void RaisePropertyChanged(object instance, string propertyName)
        {
            var type = instance.GetType();
            var propertyChanged = type.GetField("PropertyChanged", BindingFlags.Instance|BindingFlags.NonPublic);
            var handler = propertyChanged.GetValue(instance) as PropertyChangedEventHandler;
            handler(instance,new PropertyChangedEventArgs(propertyName));
        }
    }
}
