using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DynamicProxyPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成一个动态代理类型并返回
            var type = CreateDynamicProxyType();
            //使用Activator和上面的动态代理类型实例化它的一个对象
            var dynamicProxy = Activator.CreateInstance(type, new object[] { new MySinaService() }) as ISinaService;
            //调用真实对象的方法
            dynamicProxy.SendMsg("test msg");
            ReadLine();
        }

        private static Type CreateDynamicProxyType()
        {
            //所有的Reflection.Emit方法都在这里
            //1 定义AssemblyName
            var assemblyName = new AssemblyName("MyProxies");
            //2 DefineDynamicAssembly为你指定的程序集返回一个AssemblyBuilder
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            //3 使用AssemblyBuilder创建ModuleBuilder
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyProxies");

            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                "MySinaServiceProxy",//要创建的类型的名称
                TypeAttributes.Public | TypeAttributes.Class,//类型的特性
                typeof(object),//基类
                new[] { typeof(ISinaService) }//实现的接口
                );

            FieldBuilder fieldBuilder = typeBuilder.DefineField(
                "_realObject",
                typeof(MySinaService),
                FieldAttributes.Private
                );

            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.HasThis,
                new[] { typeof(MySinaService) }
                );
            ILGenerator ilgenerator = constructorBuilder.GetILGenerator();

            //将this加载到计算栈
            ilgenerator.Emit(OpCodes.Ldarg_0);
            //将构造函数的形参加载到栈
            ilgenerator.Emit(OpCodes.Ldarg_1);
            //将计算结果保存到字段
            ilgenerator.Emit(OpCodes.Stfld, fieldBuilder);
            //从构造函数返回
            ilgenerator.Emit(OpCodes.Ret);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "SendMsg",//方法名称
                MethodAttributes.Public | MethodAttributes.Virtual,//方法修饰符
                typeof(void),//无返回值
                new[] { typeof(string) }//有个字符串参数
                );
            //指定要构建的方法实现了ISinaService接口的SendMsg方法
            typeBuilder.DefineMethodOverride(
                methodBuilder,
                typeof(ISinaService).GetMethod("SendMsg")
                );
            //获取一个ILGenerator将代码添加到SendMsg方法
            ILGenerator sendMsgIlGenerator = methodBuilder.GetILGenerator();
            //加载字符串变量到计算栈
            sendMsgIlGenerator.Emit(OpCodes.Ldstr, "Before");
            //调用Console类的静态WriteLine方法
            sendMsgIlGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
            //将参数argument0（this）加载到栈
            sendMsgIlGenerator.Emit(OpCodes.Ldarg_0);
            //将字段_realObject加载到栈
            sendMsgIlGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            //加载SendMsg的参数到栈
            sendMsgIlGenerator.Emit(OpCodes.Ldarg_1);
            //调用字段上的SendMsg方法
            sendMsgIlGenerator.Emit(OpCodes.Call, fieldBuilder.FieldType.GetMethod("SendMsg"));
            //加载字符串After到栈
            sendMsgIlGenerator.Emit(OpCodes.Ldstr, "After");
            //调用Console类的静态WriteLine方法
            sendMsgIlGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
            //返回
            sendMsgIlGenerator.Emit(OpCodes.Ret);

            return typeBuilder.CreateType();
        }
    }
}

