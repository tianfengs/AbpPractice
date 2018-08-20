using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
            try
            {
                //从工厂中获取Schedule实例
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                //开启调度
                scheduler.Start();

                //创建1个job,并绑定到HelloJob类
                IJobDetail job = JobBuilder.Create<HelloJob>()
                    .WithIdentity("job1", "group1")
                    .UsingJobData("JobSays", "hello,world!")
                    .UsingJobData("JobTimeElapsed", 10)
                    .Build();

                //创建假日日历
                var calendar = new HolidayCalendar();
                calendar.AddExcludedDate(new DateTime(2017, 5, 14));
                scheduler.AddCalendar("myHolidays", calendar, false, true);
                //定义触发器，触发该job运行，并每隔10s运行一次
                ITrigger trigger = TriggerBuilder.Create().
                    WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(10)
                    .RepeatForever())
                    .Build();

                ITrigger trigger2 = TriggerBuilder.Create()
                    .WithIdentity("trigger2", "group1")
                    .ForJob("job1")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(9, 30))//每天执行时间
                    .ModifiedByCalendar("myHolidays")//但是排除假日时间
                    .Build();

                ITrigger trigger3 = TriggerBuilder.Create()
                    .WithIdentity("trigger3", "group1")
                    .ForJob(job)
                    .WithSimpleSchedule(
                    x => x.WithIntervalInSeconds(10)//每10s触发一次
                    .WithRepeatCount(10))//共触发11次
                    .Build();
                ISimpleTrigger trigger4 = TriggerBuilder.Create()
                    .ForJob(job)
                    .WithIdentity("trigger4", "group1")
                    .StartAt(DateBuilder.FutureDate(5, IntervalUnit.Second))//未来5秒运行
                    .Build() as ISimpleTrigger;
                //告诉quartz使用上面定义的触发器调度job
                //scheduler.ScheduleJob(job, trigger);
                //scheduler.ScheduleJob(job, trigger2);
                scheduler.ScheduleJob(job, trigger3);
                //睡眠1min 展示发生的事情
                Thread.Sleep(TimeSpan.FromSeconds(600));

                //当程序结束时 关闭调度任务
                scheduler.Shutdown();
            }
            catch (SchedulerException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
