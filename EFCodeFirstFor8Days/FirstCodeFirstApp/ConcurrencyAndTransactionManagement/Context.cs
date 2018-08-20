using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcurrencyAndTransactionManagement;
using ConcurrencyAndTransactionManagement.Transactions;

namespace ConcurrencyAndTransactionManagement
{
    public class Context:DbContext
    {
        public Context()
            : base("name=ConcurrencyAndTransactionManagementConn")
        {
            
        }

        public Context(DbConnection conn, bool contextOwnsConnection)
            : base(conn, contextOwnsConnection)
        {
            
        }
        public virtual DbSet<Donator> Donators { get; set; }
        public virtual DbSet<InputAccount> InputAccounts { get; set; }
        public virtual DbSet<OutputAccount> OutputAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donator>().Property(d => d.RowVersion).IsRowVersion();
            base.OnModelCreating(modelBuilder);
        }
    }
}
