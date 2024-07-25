using InsuranceConsultingOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Infrastructure.Repository.DBContext;

public partial class InsuranceDbContext : DbContext
{
    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

    public virtual DbSet<Assignament> Assignments { get; set; }

    public virtual DbSet<Insured> Insureds { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-2799MO7\\MSSQLSERVERDEV;Database=InsuranceDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignament>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E7797346CDC");

            entity.HasOne(d => d.Insured).WithMany(p => p.Assignaments)
                .HasForeignKey(d => d.InsuredId)
                .HasConstraintName("FK__Assignmen__Insur__3D5E1FD2");

            entity.HasOne(d => d.Policy).WithMany(p => p.Assignaments)
                .HasForeignKey(d => d.PolicyId)
                .HasConstraintName("FK__Assignmen__Polic__3E52440B");
        });

        modelBuilder.Entity<Insured>(entity =>
        {
            entity.HasKey(e => e.InsuredId).HasName("PK__Insureds__03C4A17B05F7AC78");

            entity.HasIndex(e => e.IdCard, "UQ__Insureds__3B7B33C33D87083D").IsUnique();

            entity.Property(e => e.IdCard).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Policies__2E1339A40BEA64CA");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.InsuredAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
