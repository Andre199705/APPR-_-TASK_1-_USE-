using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using APPR___TASK_1__USE_.Models;

namespace APPR___TASK_1__USE_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<APPR___TASK_1__USE_.Models.Donations> Donations { get; set; }
        public DbSet<APPR___TASK_1__USE_.Models.CashDonations> CashDonations { get; set; }
        public DbSet<APPR___TASK_1__USE_.Models.Disaster> Disaster { get; set; }

        public DbSet<APPR___TASK_1__USE_.Models.Categories> Categories { get; set; }

        public DbSet<APPR___TASK_1__USE_.Models.AlocatedGoods> AlocatedGoods { get; set; }

        public DbSet<APPR___TASK_1__USE_.Models.AllocatedFunds> AllocatedFunds { get; set; }

    }
}
