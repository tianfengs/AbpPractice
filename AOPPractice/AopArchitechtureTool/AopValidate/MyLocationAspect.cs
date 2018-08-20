using System;
using PostSharp.Aspects;
using PostSharp.Reflection;
using PostSharp.Extensibility;

namespace AopValidate
{
    [Serializable]
    public class MyLocationAspect:LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine("Now in getter of property");
            args.ProceedGetValue();
        }

        public override bool CompileTimeValidate(LocationInfo locationInfo)
        {
            if (!locationInfo.Name.ToLower().Equals("farb"))
            {
                //locationInfo是关于属性的反射信息
                //Message是PostSharp提供的API
                //SeverityType是一个定义消息严重级别的枚举
                Message.Write(locationInfo, SeverityType.Error, "MyCompileErrorCode01", "The name of property must be farb,not case sentive");
                return false;
            }
            return true;
        }

    }
}
