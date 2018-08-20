using PostSharp.Aspects;
using System;
using System.Windows.Forms;
using System.Reflection;
using PostSharp.Extensibility;

namespace RevisitThread
{
    [Serializable]
    public class UIThread:MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //var form =(Form) args.Instance;
            //if (form.InvokeRequired)
            //{
            //    form.Invoke(new Action(args.Proceed));
            //}
            //else
            //{
            //    args.Proceed();
            //}

            var form = args.Instance as Form;
            if (form==null)
            {
                args.Proceed();
            }
            if (form.InvokeRequired)
            {
                form.Invoke(new Action(args.Proceed));
            }
            else
            {
                args.Proceed();
            }
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            //使用IsAssignableFrom检查DeclaringType是否从Form继承
            if (typeof(Form).IsAssignableFrom(method.DeclaringType))
            {
                return true;
            }
            else
            {
                string errMsg = $"UIThread must be used in Form.[Assembly:{method.DeclaringType.Assembly.FullName},Class:{method.DeclaringType},method:{method.Name}]";
                PostSharp.Extensibility.Message.Write(
                    method,
                    SeverityType.Error,
                    "UIThreadFormError01",
                    errMsg
                    );
                return false;
            }
        }
    }
}
