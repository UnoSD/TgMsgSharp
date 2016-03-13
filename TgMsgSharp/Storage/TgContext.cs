using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using SQLite.CodeFirst;
using TgMsgSharp.Connector;

namespace Storage
{
    public class TgContext : DbContext
    {
        public DbSet<TgMessage> Messages { get; set; }

        public TgContext(FileSystemInfo databaseFileInfo) : base(new SQLiteConnection { ConnectionString = $"Data Source={databaseFileInfo.FullName};" }, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ApplyKeys(modelBuilder);
            ApplyIndexes(modelBuilder);
            ApplyExclusions(modelBuilder);

            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<TgContext>(modelBuilder);

            Database.SetInitializer(sqliteConnectionInitializer);
        }

        static void ApplyExclusions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TgMessage>().Ignore(tgMessage => tgMessage.SmallImage);
        }

        static void ApplyIndexes(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TgMessage>()
            //            .Property(tgMessage => tgMessage.Date)
            //            .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Date") { IsUnique = false, IsClustered = false }));
        }

        static void ApplyKeys(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TgMessage>().HasKey(tgMessage => new { tgMessage.Id, tgMessage.Date });
            //modelBuilder.Entity<TgMessage>().HasKey(tgMessage => tgMessage.Id);
        }
    }
}