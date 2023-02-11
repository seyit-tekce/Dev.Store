using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.Keywords;
using Dev.Store.Locations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Dev.Store.UploadFiles;

namespace Dev.Store.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class StoreDbContext :
    AbpDbContext<StoreDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
   
    public DbSet<UploadFile> UploadFiles { get; set; }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(StoreConsts.DbTablePrefix + "YourEntities", StoreConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});


        builder.Entity<Brand>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "Brands", StoreConsts.DbSchema);
            b.HasIndex(a => a.Code);
            b.Property(t => t.Name).IsRequired().HasMaxLength(128);
            b.Property(t => t.Code).IsRequired().HasMaxLength(12);

            b.ConfigureByConvention();



        });


        builder.Entity<Category>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "Categories", StoreConsts.DbSchema);
            b.HasIndex(x => x.Link);
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Link).IsRequired().HasMaxLength(256);
            b.HasMany(c => c.CategoryChildren).WithOne(a => a.CategoryParent).HasForeignKey(g => g.CategoryParentId);
            b.ConfigureByConvention();


        });


        builder.Entity<Location>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "Locations", StoreConsts.DbSchema);
            b.HasIndex(a => a.Code);
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Code).IsRequired();
            b.HasMany(c => c.LocationChildren).WithOne(a => a.LocationParent).HasForeignKey(g => g.LocationParentId);
            b.ConfigureByConvention();


            /* Configure more properties here */
        });
        builder.ConfigureBlobStoring();


        builder.Entity<Keyword>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "Keywords", StoreConsts.DbSchema);
            b.Property(x => x.Name).IsRequired().HasMaxLength(20);
            b.HasIndex(x => x.Name);
            b.ConfigureByConvention();


            /* Configure more properties here */
        });





        builder.Entity<UploadFile>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "UploadFiles", StoreConsts.DbSchema);
            b.Property(x => x.FileName).IsRequired();
            b.Property(x => x.FilePath).IsRequired();
            b.Property(x => x.Description);
            b.HasIndex(x => x.PublicId);
            b.ConfigureByConvention(); 
            /* Configure more properties here */
        });
    }
}
