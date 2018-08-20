using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoreProcedure.ConfigMap
{
    public class DonatorMap:EntityTypeConfiguration<Donator>
    {
        public DonatorMap()
        {
            //MapToStoredProcedures();
            MapToStoredProcedures(config =>
            {
                //将删除打赏者的默认存储过程名称更改为“DonatorDelete”，
                //同时将该存储过程的参数名称更改为“donatorId”，并指定该值来自Id属性
                config.Delete(
                    procConfig =>
                    {
                        procConfig.HasName("DonatorDelete");
                        procConfig.Parameter(d => d.Id, "donatorId");
                    });

                //将默认的插入存储过程名称更改为“DonatorInsert”
                config.Insert(
                    procConfig =>
                    {
                        procConfig.HasName("DonatorInsert");
                    });
                //将默认的更新存储过程名称更改为“DonatorUpdate”
                config.Update(procConfig =>
                {
                    procConfig.HasName("DonatorUpdate");
                });

            });
        }            
    }
}
