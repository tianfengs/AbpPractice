using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Constraints;
using PostSharp.Extensibility;
using System.Reflection;

namespace ArchitectureConstraints
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class)]//约束用在类上
    public class NhEntityAttribute : ScalarConstraint
    {
        public override void ValidateCode(object target)//注意这次只有一个参数，没有assembly参数
        {
            //因为目标是类，所以可转成Type类型
            var targetType = (Type)target;

            //获取实例的所有公共属性
            var properties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !p.GetGetMethod().IsVirtual);//且属性不是虚拟的

            foreach (PropertyInfo p in properties)
            {
                //对于没有virtual修饰的属性，打印错误消息
                Message.Write(targetType, SeverityType.Error,
                    "NhVirtual001",
                    $"Property {p.Name} in entity class {targetType.FullName} is not virtual .");
            }
        }
    }
}
