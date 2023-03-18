using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.Keywords;
using Dev.Store.Locations;
using Dev.Store.ProductImages;
using Dev.Store.Products;
using Dev.Store.ProductSets;
using Dev.Store.ProductSizes;
using Dev.Store.SeoSettings;
using Dev.Store.UploadFiles;
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
using Volo.CmsKit.EntityFrameworkCore;

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

    #endregion Entities from the modules

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Keyword> Keywords { get; set; }

    public DbSet<UploadFile> UploadFiles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSet> ProductSets { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<SeoSetting> SeoSettings { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

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
            b.HasOne(x => x.File).WithOne(x => x.Category);
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
        builder.ConfigureCmsKit();

        builder.Entity<Product>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "Products", StoreConsts.DbSchema);
            b.Property(X => X.Name).IsRequired();
            b.Property(x => x.Code).IsRequired();
            b.Property(x => x.Description).IsRequired();
            b.Property(x => x.CategoryId).IsRequired();
            b.Property(x => x.BrandId);

            b.HasIndex(x => x.CategoryId);

            b.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            b.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            b.HasMany(x => x.ProductSizes).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            b.HasMany(x => x.ProductSets).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            b.HasMany(x => x.ProductImages).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            b.ConfigureByConvention();

            /* Configure more properties here */
        });

        builder.Entity<ProductSet>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "ProductSets", StoreConsts.DbSchema);
            b.Property(x => x.ProductId).IsRequired();
            b.Property(x => x.Code).IsRequired();
            b.Property(x => x.SetName).IsRequired();
            b.Property(x => x.Price).IsRequired();
            b.Property(x => x.Amount).IsRequired().HasDefaultValue(1);
            b.Property(x => x.IsOptional).IsRequired();

            b.HasIndex(x => x.Code);
            b.HasOne(x => x.Product).WithMany(x => x.ProductSets).HasForeignKey(x => x.ProductId);

            b.ConfigureByConvention();

            /* Configure more properties here */
        });

        builder.Entity<ProductSize>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "ProductSizes", StoreConsts.DbSchema);
            b.Property(x => x.ProductId).IsRequired();
            b.Property(x => x.Code).IsRequired();
            b.Property(x => x.Price).IsRequired();
            b.Property(x => x.Width).IsRequired();
            b.Property(x => x.Height).IsRequired();
            b.Property(x => x.Depth).IsRequired(false);
            b.HasIndex(x => x.Code);
            b.HasOne(x => x.Product).WithMany(x => x.ProductSizes).HasForeignKey(x => x.ProductId);
            b.ConfigureByConvention();

            /* Configure more properties here */
        });

        builder.Entity<SeoSetting>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "SeoSettings", StoreConsts.DbSchema);
            b.Property(x => x.ProductId).IsRequired();
            b.Property(x => x.Title).IsRequired();
            b.Property(x => x.Keywords).IsRequired();
            b.Property(x => x.Description).IsRequired();

            b.HasOne(x => x.Product).WithOne(x => x.SeoSetting);
            b.ConfigureByConvention();

            /* Configure more properties here */
        });

        builder.Entity<ProductImage>(b =>
        {
            b.ToTable(StoreConsts.DbTablePrefix + "ProductImages", StoreConsts.DbSchema);
            b.Property(x => x.ProductId).IsRequired();
            b.Property(x => x.IsMain).IsRequired();
            b.Property(x => x.UploadFileId).IsRequired();
            b.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
            b.HasOne(x => x.UploadFile).WithMany(x => x.ProductImages).HasForeignKey(x => x.UploadFileId);
            b.HasIndex(x => x.ProductId);

            b.ConfigureByConvention();

            /* Configure more properties here */
        });
    }
}