﻿using Abp.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}