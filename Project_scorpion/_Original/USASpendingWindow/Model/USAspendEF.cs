using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace USAspendingWindow
{
    public class USAspendEF : DbContext
    {
        public USAspendEF() : base("name=ConnectionString") { }
        public DbSet<Loadtracking> Audit { get; set; }
        public DbSet<Current_usaspend> Contracts { get; set; }
        public DbSet<OutOfScope_usaspend> Outofscopes { get; set; }
        public DbSet<outofscopefilter> Outofscopefilters { get; set; }

        public DbSet<usaspend_gui_config> GUIconfig { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<outofscopefilter>().ToTable("outofscopefilter");
            modelBuilder.Entity<outofscopefilter>().HasKey(p => p.id);
            modelBuilder.Entity<outofscopefilter>().Property(c => c.id
                );
            modelBuilder.Entity<Current_usaspend>().ToTable("Current_usaspend");
            modelBuilder.Entity<Current_usaspend>().HasKey(p => p.unique_transaction_id);
            modelBuilder.Entity<Current_usaspend>().Property(c => c.unique_transaction_id);

            modelBuilder.Entity<Loadtracking>().ToTable("Loadtracking");
            modelBuilder.Entity<Loadtracking>().HasKey(p => p.id);
            modelBuilder.Entity<Loadtracking>().Property(c => c.id
                );
            modelBuilder.Entity<OutOfScope_usaspend>().ToTable("OutOfScope_usaspend");
            modelBuilder.Entity<OutOfScope_usaspend>().HasKey(p => p.unique_transaction_id);
            modelBuilder.Entity<OutOfScope_usaspend>().Property(c => c.unique_transaction_id);

            modelBuilder.Entity<usaspend_gui_config>().ToTable("usaspend_gui_config");
            modelBuilder.Entity<usaspend_gui_config>().HasKey(p => p.id);
            modelBuilder.Entity<usaspend_gui_config>().Property(c => c.id);
 
            //modelBuilder.Entity<Contact>().HasRequired(p => p.Department)
            //    .WithMany(b => b.Contacts).HasForeignKey(b => b.DepartmentID);
            base.OnModelCreating(modelBuilder);
        }

    }
}
