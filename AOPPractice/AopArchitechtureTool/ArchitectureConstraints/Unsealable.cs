using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace ArchitectureConstraints
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class)]
    public class Unsealable : ReferentialConstraint
    {
        public override void ValidateCode(object target, Assembly assembly)
        {
            //目标类型是一个标记为Unsealable的类
            var targetType = (Type)target;

            List<Type> sealedSubClasses = assembly.GetTypes()//获得所有类型
                .Where(t => t.IsSealed)//类型是密封的
                .Where(t => targetType.IsAssignableFrom(t))//类型继承自目标类型
                .ToList();

            //遍历所有密封子类
            sealedSubClasses.ForEach(s =>
            {
                //为每个类输出错误信息
                Message.Write(s, SeverityType.Error,
                    "Unsealable001",
                    $"Error on {s.FullName}.Subclasses of {targetType.FullName}  cannot be sealed."
                    );
            });
        }
    }
}
