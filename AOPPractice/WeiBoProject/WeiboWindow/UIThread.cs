using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostSharp.Aspects;

namespace WeiboWindow
{
    [Serializable]
    public class UIThread : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var form = args.Instance as Form;
            if (form.InvokeRequired)
                form.Invoke(new Action(args.Proceed));
            else
                args.Proceed();
        }
    }
}
