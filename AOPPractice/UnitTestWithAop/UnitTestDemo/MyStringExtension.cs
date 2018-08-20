using System.Linq;

namespace PostSharpUT
{
    public class MyStringExtension
    {
        /// <summary>
        /// 创建一个反转字符串的方法，比如 输入hello，返回olleh
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            //return str;//现在暂时直接返回，为了看看测试的效果
            return new string(str.Reverse().ToArray());
        }
    }
}
