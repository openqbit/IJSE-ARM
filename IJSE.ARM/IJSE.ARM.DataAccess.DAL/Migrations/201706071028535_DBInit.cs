namespace IJSE.ARM.DataAccess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AGOffice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.District", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Province", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AidAllocationDistributed",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidRequestDetailId = c.Int(nullable: false),
                        AidDistributionItemDetailId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                        RecivedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AidAllocationPending",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidRequestDetailId = c.Int(nullable: false),
                        DonationRequestDetailId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AidAllocationRecived",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidRequestDetailId = c.Int(nullable: false),
                        DonationRecivedDetailId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AidDistribution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ETA = c.DateTime(nullable: false),
                        DeployedDate = c.DateTime(nullable: false),
                        OfficerInChargeId = c.Int(nullable: false),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                        DisasterMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisasterMaster", t => t.DisasterMasterId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.OfficerInChargeId, cascadeDelete: true)
                .Index(t => t.OfficerInChargeId)
                .Index(t => t.DisasterMasterId);
            
            CreateTable(
                "dbo.DisasterMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        DisasterTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisasterType", t => t.DisasterTypeId, cascadeDelete: true)
                .Index(t => t.DisasterTypeId);
            
            CreateTable(
                "dbo.DisasterType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        DOB = c.DateTime(),
                        NIC = c.String(),
                        MobileNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.AidDistributionConvoy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidDistributionId = c.Int(nullable: false),
                        TotalVehicles = c.Int(nullable: false),
                        Root = c.String(),
                        GPSLocations = c.String(),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AidDistribution", t => t.AidDistributionId, cascadeDelete: true)
                .Index(t => t.AidDistributionId);
            
            CreateTable(
                "dbo.AidDistributionConvoyVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidDistributionConvoyId = c.Int(nullable: false),
                        VehicleNumber = c.String(),
                        VehicleType = c.String(),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AidDistributionConvoy", t => t.AidDistributionConvoyId, cascadeDelete: true)
                .Index(t => t.AidDistributionConvoyId);
            
            CreateTable(
                "dbo.AidDistributionItemDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AidDistributionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        ItemSubCategoryId = c.Int(nullable: false),
                        ParentitemId = c.Int(),
                        RatioToParentItem = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemSubCategoryIII", t => t.ItemSubCategoryId, cascadeDelete: true)
                .Index(t => t.ItemSubCategoryId);
            
            CreateTable(
                "dbo.ItemSubCategoryIII",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemSubCategoryII", t => t.ItemSubCategoryId, cascadeDelete: true)
                .Index(t => t.ItemSubCategoryId);
            
            CreateTable(
                "dbo.ItemSubCategoryII",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemSubCategoryI", t => t.ItemSubCategoryId, cascadeDelete: true)
                .Index(t => t.ItemSubCategoryId);
            
            CreateTable(
                "dbo.ItemSubCategoryI",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategory", t => t.ItemSubCategoryId, cascadeDelete: true)
                .Index(t => t.ItemSubCategoryId);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AidRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        FamilyId = c.Int(nullable: false),
                        DisasterMasterId = c.Int(nullable: false),
                        ImagePathRef = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisasterMaster", t => t.DisasterMasterId, cascadeDelete: true)
                .ForeignKey("dbo.Family", t => t.FamilyId, cascadeDelete: true)
                .Index(t => t.FamilyId)
                .Index(t => t.DisasterMasterId);
            
            CreateTable(
                "dbo.Family",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        NoOfMembers = c.Int(nullable: false),
                        GSAreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GSArea", t => t.GSAreaId, cascadeDelete: true)
                .Index(t => t.GSAreaId);
            
            CreateTable(
                "dbo.GSArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AGOfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AGOffice", t => t.AGOfficeId, cascadeDelete: true)
                .Index(t => t.AGOfficeId);
            
            CreateTable(
                "dbo.AidRequestDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        AidItemId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.AidItemId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.AidItemId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TelLand = c.String(),
                        TelMobile = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonationRecived",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        DonationRequestId = c.Int(nullable: false),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                        AcceptedOfficerId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.AcceptedOfficerId, cascadeDelete: true)
                .ForeignKey("dbo.DonationRequest", t => t.DonationRequestId, cascadeDelete: true)
                .Index(t => t.DonationRequestId)
                .Index(t => t.AcceptedOfficerId);
            
            CreateTable(
                "dbo.DonationRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        DisasterMasterId = c.Int(nullable: false),
                        DonorId = c.Int(nullable: false),
                        ImagePathRef = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisasterMaster", t => t.DisasterMasterId, cascadeDelete: true)
                .ForeignKey("dbo.Donor", t => t.DonorId, cascadeDelete: true)
                .Index(t => t.DisasterMasterId)
                .Index(t => t.DonorId);
            
            CreateTable(
                "dbo.Donor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorType = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonorPeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsPrimaryContact = c.Boolean(nullable: false, defaultValue: false),
                        DonorId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donor", t => t.DonorId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.DonorId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.DonationRecivedDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationRecivedId = c.Int(nullable: false),
                        AidItemId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        ImagePathRef = c.String(),
                        RefNotes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.AidItemId, cascadeDelete: true)
                .ForeignKey("dbo.DonationRecived", t => t.DonationRecivedId, cascadeDelete: true)
                .Index(t => t.DonationRecivedId)
                .Index(t => t.AidItemId);
            
            CreateTable(
                "dbo.DonationRequestDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationRequestId = c.Int(nullable: false),
                        AidItemId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.AidItemId, cascadeDelete: true)
                .ForeignKey("dbo.DonationRequest", t => t.DonationRequestId, cascadeDelete: true)
                .Index(t => t.DonationRequestId)
                .Index(t => t.AidItemId);
            
            CreateTable(
                "dbo.DonorCompany",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Donor", t => t.DonorId, cascadeDelete: true)
                .Index(t => t.DonorId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.FamilyDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        IsPrimaryMember = c.Boolean(nullable: false, defaultValue: false),
                        FamilyId = c.Int(nullable: false),
                        FamilyMemeberType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Family", t => t.FamilyId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.FamilyId);
            
            CreateTable(
                "dbo.SystemUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserHashedPwd = c.String(),
                        AccessLevel = c.String(),
                        PersonId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUser", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Item", "ItemSubCategoryId", "dbo.ItemSubCategoryIII");
            DropForeignKey("dbo.FamilyDetail", "PersonId", "dbo.Person");
            DropForeignKey("dbo.FamilyDetail", "FamilyId", "dbo.Family");
            DropForeignKey("dbo.DonorCompany", "DonorId", "dbo.Donor");
            DropForeignKey("dbo.DonorCompany", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.DonationRequestDetail", "DonationRequestId", "dbo.DonationRequest");
            DropForeignKey("dbo.DonationRequestDetail", "AidItemId", "dbo.Item");
            DropForeignKey("dbo.DonationRecivedDetail", "DonationRecivedId", "dbo.DonationRecived");
            DropForeignKey("dbo.DonationRecivedDetail", "AidItemId", "dbo.Item");
            DropForeignKey("dbo.DonationRecived", "DonationRequestId", "dbo.DonationRequest");
            DropForeignKey("dbo.DonationRequest", "DonorId", "dbo.Donor");
            DropForeignKey("dbo.DonorPeople", "PersonId", "dbo.Person");
            DropForeignKey("dbo.DonorPeople", "DonorId", "dbo.Donor");
            DropForeignKey("dbo.DonationRequest", "DisasterMasterId", "dbo.DisasterMaster");
            DropForeignKey("dbo.DonationRecived", "AcceptedOfficerId", "dbo.Person");
            DropForeignKey("dbo.AidRequestDetail", "PersonId", "dbo.Person");
            DropForeignKey("dbo.AidRequestDetail", "AidItemId", "dbo.Item");
            DropForeignKey("dbo.AidRequest", "FamilyId", "dbo.Family");
            DropForeignKey("dbo.Family", "GSAreaId", "dbo.GSArea");
            DropForeignKey("dbo.GSArea", "AGOfficeId", "dbo.AGOffice");
            DropForeignKey("dbo.AidRequest", "DisasterMasterId", "dbo.DisasterMaster");
            DropForeignKey("dbo.ItemSubCategoryIII", "ItemSubCategoryId", "dbo.ItemSubCategoryII");
            DropForeignKey("dbo.ItemSubCategoryII", "ItemSubCategoryId", "dbo.ItemSubCategoryI");
            DropForeignKey("dbo.ItemSubCategoryI", "ItemSubCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.AidDistributionConvoyVehicles", "AidDistributionConvoyId", "dbo.AidDistributionConvoy");
            DropForeignKey("dbo.AidDistributionConvoy", "AidDistributionId", "dbo.AidDistribution");
            DropForeignKey("dbo.AidDistribution", "OfficerInChargeId", "dbo.Person");
            DropForeignKey("dbo.AidDistribution", "DisasterMasterId", "dbo.DisasterMaster");
            DropForeignKey("dbo.DisasterMaster", "DisasterTypeId", "dbo.DisasterType");
            DropForeignKey("dbo.AGOffice", "DistrictId", "dbo.District");
            DropForeignKey("dbo.District", "ProvinceId", "dbo.Province");
            DropIndex("dbo.SystemUser", new[] { "PersonId" });
            DropIndex("dbo.FamilyDetail", new[] { "FamilyId" });
            DropIndex("dbo.FamilyDetail", new[] { "PersonId" });
            DropIndex("dbo.DonorCompany", new[] { "CompanyId" });
            DropIndex("dbo.DonorCompany", new[] { "DonorId" });
            DropIndex("dbo.DonationRequestDetail", new[] { "AidItemId" });
            DropIndex("dbo.DonationRequestDetail", new[] { "DonationRequestId" });
            DropIndex("dbo.DonationRecivedDetail", new[] { "AidItemId" });
            DropIndex("dbo.DonationRecivedDetail", new[] { "DonationRecivedId" });
            DropIndex("dbo.DonorPeople", new[] { "PersonId" });
            DropIndex("dbo.DonorPeople", new[] { "DonorId" });
            DropIndex("dbo.DonationRequest", new[] { "DonorId" });
            DropIndex("dbo.DonationRequest", new[] { "DisasterMasterId" });
            DropIndex("dbo.DonationRecived", new[] { "AcceptedOfficerId" });
            DropIndex("dbo.DonationRecived", new[] { "DonationRequestId" });
            DropIndex("dbo.AidRequestDetail", new[] { "AidItemId" });
            DropIndex("dbo.AidRequestDetail", new[] { "PersonId" });
            DropIndex("dbo.GSArea", new[] { "AGOfficeId" });
            DropIndex("dbo.Family", new[] { "GSAreaId" });
            DropIndex("dbo.AidRequest", new[] { "DisasterMasterId" });
            DropIndex("dbo.AidRequest", new[] { "FamilyId" });
            DropIndex("dbo.ItemSubCategoryI", new[] { "ItemSubCategoryId" });
            DropIndex("dbo.ItemSubCategoryII", new[] { "ItemSubCategoryId" });
            DropIndex("dbo.ItemSubCategoryIII", new[] { "ItemSubCategoryId" });
            DropIndex("dbo.Item", new[] { "ItemSubCategoryId" });
            DropIndex("dbo.AidDistributionConvoyVehicles", new[] { "AidDistributionConvoyId" });
            DropIndex("dbo.AidDistributionConvoy", new[] { "AidDistributionId" });
            DropIndex("dbo.DisasterMaster", new[] { "DisasterTypeId" });
            DropIndex("dbo.AidDistribution", new[] { "DisasterMasterId" });
            DropIndex("dbo.AidDistribution", new[] { "OfficerInChargeId" });
            DropIndex("dbo.District", new[] { "ProvinceId" });
            DropIndex("dbo.AGOffice", new[] { "DistrictId" });
            DropTable("dbo.SystemUser");
            DropTable("dbo.FamilyDetail");
            DropTable("dbo.DonorCompany");
            DropTable("dbo.DonationRequestDetail");
            DropTable("dbo.DonationRecivedDetail");
            DropTable("dbo.DonorPeople");
            DropTable("dbo.Donor");
            DropTable("dbo.DonationRequest");
            DropTable("dbo.DonationRecived");
            DropTable("dbo.Company");
            DropTable("dbo.AidRequestDetail");
            DropTable("dbo.GSArea");
            DropTable("dbo.Family");
            DropTable("dbo.AidRequest");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.ItemSubCategoryI");
            DropTable("dbo.ItemSubCategoryII");
            DropTable("dbo.ItemSubCategoryIII");
            DropTable("dbo.Item");
            DropTable("dbo.AidDistributionItemDetail");
            DropTable("dbo.AidDistributionConvoyVehicles");
            DropTable("dbo.AidDistributionConvoy");
            DropTable("dbo.Person");
            DropTable("dbo.DisasterType");
            DropTable("dbo.DisasterMaster");
            DropTable("dbo.AidDistribution");
            DropTable("dbo.AidAllocationRecived");
            DropTable("dbo.AidAllocationPending");
            DropTable("dbo.AidAllocationDistributed");
            DropTable("dbo.Province");
            DropTable("dbo.District");
            DropTable("dbo.AGOffice");
        }
    }
}
