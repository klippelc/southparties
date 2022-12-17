namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(unicode: false),
                        City = c.String(unicode: false),
                        State = c.String(unicode: false),
                        DomainKey = c.String(nullable: false, maxLength: 48, unicode: false),
                        DisplayOrder = c.Byte(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(maxLength: 48, unicode: false),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 48, unicode: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 48, unicode: false),
                        UpdatedOn = c.DateTime(),
                        DeactivatedBy = c.String(maxLength: 48, unicode: false),
                        DeactivatedOn = c.DateTime(),
                        Description = c.String(maxLength: 512, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DomainKey, unique: true);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 48, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 24, unicode: false),
                        EmployeeId = c.String(maxLength: 24, unicode: false),
                        DomainKey = c.String(nullable: false, maxLength: 48, unicode: false),
                        DisplayOrder = c.Byte(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(maxLength: 48, unicode: false),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 48, unicode: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 48, unicode: false),
                        UpdatedOn = c.DateTime(),
                        DeactivatedBy = c.String(maxLength: 48, unicode: false),
                        DeactivatedOn = c.DateTime(),
                        Description = c.String(maxLength: 512, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DomainKey, unique: true);
            
            CreateStoredProcedure(
                "dbo.Person_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 48, unicode: false),
                        LastName = p.String(maxLength: 24, unicode: false),
                        EmployeeId = p.String(maxLength: 24, unicode: false),
                        DomainKey = p.String(maxLength: 48, unicode: false),
                        DisplayOrder = p.Byte(),
                        IsDeleted = p.Boolean(),
                        DeletedBy = p.String(maxLength: 48, unicode: false),
                        DeletedOn = p.DateTime(),
                        IsActive = p.Boolean(),
                        CreatedBy = p.String(maxLength: 48, unicode: false),
                        CreatedOn = p.DateTime(),
                        UpdatedBy = p.String(maxLength: 48, unicode: false),
                        UpdatedOn = p.DateTime(),
                        DeactivatedBy = p.String(maxLength: 48, unicode: false),
                        DeactivatedOn = p.DateTime(),
                        Description = p.String(maxLength: 512, unicode: false),
                    },
                body:
                    @"INSERT [dbo].[Person]([FirstName], [LastName], [EmployeeId], [DomainKey], [DisplayOrder], [IsDeleted], [DeletedBy], [DeletedOn], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeactivatedBy], [DeactivatedOn], [Description])
                      VALUES (@FirstName, @LastName, @EmployeeId, @DomainKey, @DisplayOrder, @IsDeleted, @DeletedBy, @DeletedOn, @IsActive, @CreatedBy, @CreatedOn, @UpdatedBy, @UpdatedOn, @DeactivatedBy, @DeactivatedOn, @Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Person]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Person_Update",
                p => new
                    {
                        Id = p.Int(),
                        FirstName = p.String(maxLength: 48, unicode: false),
                        LastName = p.String(maxLength: 24, unicode: false),
                        EmployeeId = p.String(maxLength: 24, unicode: false),
                        DomainKey = p.String(maxLength: 48, unicode: false),
                        DisplayOrder = p.Byte(),
                        IsDeleted = p.Boolean(),
                        DeletedBy = p.String(maxLength: 48, unicode: false),
                        DeletedOn = p.DateTime(),
                        IsActive = p.Boolean(),
                        CreatedBy = p.String(maxLength: 48, unicode: false),
                        CreatedOn = p.DateTime(),
                        UpdatedBy = p.String(maxLength: 48, unicode: false),
                        UpdatedOn = p.DateTime(),
                        DeactivatedBy = p.String(maxLength: 48, unicode: false),
                        DeactivatedOn = p.DateTime(),
                        Description = p.String(maxLength: 512, unicode: false),
                    },
                body:
                    @"UPDATE [dbo].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [EmployeeId] = @EmployeeId, [DomainKey] = @DomainKey, [DisplayOrder] = @DisplayOrder, [IsDeleted] = @IsDeleted, [DeletedBy] = @DeletedBy, [DeletedOn] = @DeletedOn, [IsActive] = @IsActive, [CreatedBy] = @CreatedBy, [CreatedOn] = @CreatedOn, [UpdatedBy] = @UpdatedBy, [UpdatedOn] = @UpdatedOn, [DeactivatedBy] = @DeactivatedBy, [DeactivatedOn] = @DeactivatedOn, [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Person_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Person]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Person_Delete");
            DropStoredProcedure("dbo.Person_Update");
            DropStoredProcedure("dbo.Person_Insert");
            DropIndex("dbo.Person", new[] { "DomainKey" });
            DropIndex("dbo.Address", new[] { "DomainKey" });
            DropTable("dbo.Person");
            DropTable("dbo.Address");
        }
    }
}
