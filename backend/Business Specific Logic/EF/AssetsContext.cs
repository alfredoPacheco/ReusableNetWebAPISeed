namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using RepositoryLogic.Entities;
    public partial class AssetsContext : DbContext
    {
        public AssetsContext()
            : base("name=AssetsContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<cat_Area> cat_Area { get; set; }
        public virtual DbSet<cat_DutyLevel> cat_DutyLevel { get; set; }
        public virtual DbSet<cat_Location> cat_Location { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<cross_Emploee_Asset> cross_Emploee_Asset { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Emploee> Emploees { get; set; }

        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .HasMany(e => e.cross_Emploee_Asset)
                .WithRequired(e => e.Asset)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asset>()
                .HasMany(e => e.cat_Area)
                .WithMany(e => e.Assets)
                .Map(m => m.ToTable("cross_Area_Asset").MapLeftKey("AssetKey").MapRightKey("AreaKey"));

            modelBuilder.Entity<cat_Location>()
                .HasMany(e => e.Companies)
                .WithRequired(e => e.cat_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cat_Location>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.cat_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Emploees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Emploee>()
                .HasMany(e => e.cross_Emploee_Asset)
                .WithRequired(e => e.Emploee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Emploee>()
                .HasMany(e => e.Emploee1)
                .WithOptional(e => e.Emploee2)
                .HasForeignKey(e => e.DirectBossKey);


            modelBuilder.Entity<User>()
                .Property(e => e.Identicon64)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Sorts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Sort_User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Gridsters)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Gridster_User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks)
                .WithOptional(e => e.User_LastEditedBy)
                .HasForeignKey(e => e.User_LastEditedByKey);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks1)
                .WithOptional(e => e.User_RemovedBy)
                .HasForeignKey(e => e.User_RemovedByKey);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks2)
                .WithOptional(e => e.User_AssignedTo)
                .HasForeignKey(e => e.User_AssignedToKey);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks3)
                .WithOptional(e => e.User_AssignedBy)
                .HasForeignKey(e => e.User_AssignedByKey);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks4)
                .WithRequired(e => e.User_CreatedBy)
                .HasForeignKey(e => e.User_CreatedByKey);
        }
    }
}
