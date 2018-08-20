using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HelloJob : IJob
    {
        public string JobSays { private get; set; }
        public int JobTimeElapsed{ private get; set; }
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Greeting from HelloJob!");
            JobKey key= context.JobDetail.Key;
            //写法1：一个个手动获取
            //JobDataMap dataMap = context.JobDetail.JobDataMap;
            //string hello = dataMap.GetString("job says");
            //int time = dataMap.GetInt("job time elapsed");
            //Console.WriteLine("Instance {0} of HelloJob says:{1},time：{2}",key,hello,time);
            JobDataMap dataMap2 = context.MergedJobDataMap;
            Console.WriteLine("Instance {0} of HelloJob says:{1},time：{2}",key,JobSays, JobTimeElapsed);


        }
    }
}
