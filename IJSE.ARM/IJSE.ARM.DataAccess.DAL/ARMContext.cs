using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using IJSE.ARM.Common.Models;

namespace IJSE.ARM.DataAccess.DAL
{
    public class ARMContext : DbContext
    {
        public ARMContext() : base("ARMContextDb")
        {

            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<AGOffice> AGOffice { get; set; }
        public DbSet<AidAllocationDistributed> AidAllocationDistributed { get; set; }
        public DbSet<AidAllocationPending> AidAllocationPending { get; set; }
        public DbSet<AidAllocationRecived> AidAllocationRecived { get; set; }
        public DbSet<AidDistribution> AidDistribution { get; set; }
        public DbSet<AidDistributionConvoy> AidDistributionConvoy { get; set; }
        public DbSet<AidDistributionConvoyVehicles> AidDistributionConvoyVehicles { get; set; }
        public DbSet<AidDistributionItemDetail> AidDistributionItemDetail { get; set; }
        public DbSet<AidItem> AidItem { get; set; }
        public DbSet<AidRequest> AidRequest { get; set; }
        public DbSet<AidRequestDetail> AidRequestDetail { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<DisasterMaster> DisasterMaster { get; set; }
        public DbSet<DisasterType> DisasterType { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<DonationRecived> DonationRecived { get; set; }
        public DbSet<DonationRecivedDetail> DonationRecivedDetail { get; set; }
        public DbSet<DonationRequest> DonationRequest { get; set; }
        public DbSet<DonationRequestDetail> DonationRequestDetail { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<DonorCompany> DonorCompany { get; set; }
        public DbSet<DonorPeople> DonorPeople { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<FamilyDetail> FamilyDetail { get; set; }
        public DbSet<GSArea> GSArea { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<ItemSubCategoryI> ItemSubCategoryI { get; set; }
        public DbSet<ItemSubCategoryII> ItemSubCategoryII { get; set; }
        public DbSet<ItemSubCategoryIII> ItemSubCategoryIII { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
