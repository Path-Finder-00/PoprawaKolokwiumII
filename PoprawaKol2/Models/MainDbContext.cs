using Microsoft.EntityFrameworkCore;

namespace PoprawaKol2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>(m =>
            {
                m.HasKey(e => new { e.MemberID, e.TeamID });
            });

            modelBuilder.Entity<File>(f =>
            {
                f.HasKey(e => new { e.FileID, e.TeamID });
            });

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(o =>
            {
                o.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "PJWSTK", OrganizationDomain = "What is a domain" },
                    new Organization { OrganizationID = 2, OrganizationName = "PJATK", OrganizationDomain = "Like https?" },
                    new Organization { OrganizationID = 3, OrganizationName = "PJAIT", OrganizationDomain = "I don't get it" }
                );
            });

            modelBuilder.Entity<Member>(m =>
            {
                m.HasData(
                    new Member { MemberID = 1, OrganizationID = 1, MemberName = "Jan", MemberSurname = "Kowalski", MemberNickName = "xXDevastatorXx" },
                    new Member { MemberID = 2, OrganizationID = 2, MemberName = "Adrian", MemberSurname = "Kura", MemberNickName = "GodKiller420BlazeIt" },
                    new Member { MemberID = 3, OrganizationID = 3, MemberName = "Michał", MemberSurname = "Góra" }
                );
            });

            modelBuilder.Entity<Team>(t =>
            {
                t.HasData(
                    new Team { TeamID = 1, OrganizationID = 1, TeamName = "NAI", TeamDescription = "Cool subject" },
                    new Team { TeamID = 2, OrganizationID = 2, TeamName = "APBD", TeamDescription = "Really cool subject" },
                    new Team { TeamID = 3, OrganizationID = 3, TeamName = "PRI", TeamDescription = "Not a very cool subject" }
                );
            });

            modelBuilder.Entity<Membership>(m =>
            {
                m.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = new System.DateTime(2020, 1, 4) },
                    new Membership { MemberID = 1, TeamID = 2, MembershipDate = new System.DateTime(2020, 1, 5) },
                    new Membership { MemberID = 1, TeamID = 3, MembershipDate = new System.DateTime(2020, 1, 6) },
                    new Membership { MemberID = 2, TeamID = 1, MembershipDate = new System.DateTime(2020, 1, 4) },
                    new Membership { MemberID = 2, TeamID = 2, MembershipDate = new System.DateTime(2020, 1, 5) },
                    new Membership { MemberID = 2, TeamID = 3, MembershipDate = new System.DateTime(2020, 1, 6) },
                    new Membership { MemberID = 3, TeamID = 1, MembershipDate = new System.DateTime(2020, 1, 4) },
                    new Membership { MemberID = 3, TeamID = 2, MembershipDate = new System.DateTime(2020, 1, 5) },
                    new Membership { MemberID = 3, TeamID = 3, MembershipDate = new System.DateTime(2020, 1, 6) }
                );
            });

            modelBuilder.Entity<File>(f =>
            {
                f.HasData(
                    new File { FileID = 1, TeamID = 1, FileName = "Bayes", FileExtension = "txt", FileSize = 12345 },
                    new File { FileID = 2, TeamID = 1, FileName = "kNN", FileExtension = "txt", FileSize = 12345 },
                    new File { FileID = 3, TeamID = 2, FileName = "EFCore", FileExtension = "docx", FileSize = 12345 },
                    new File { FileID = 4, TeamID = 2, FileName = "CodeFirst", FileExtension = "docx", FileSize = 12345 },
                    new File { FileID = 5, TeamID = 3, FileName = "Class Diagram", FileExtension = "jpg", FileSize = 12345 },
                    new File { FileID = 6, TeamID = 3, FileName = "UseCase Diagram", FileExtension = "png", FileSize = 12345 }
                );
            });
        }
    }
}
