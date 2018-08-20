using Autofac;
using PatientRecords.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.DependencyInjection
{
    public class DefaultModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppointService>().As<IAppointService>();
        }
    }
}
