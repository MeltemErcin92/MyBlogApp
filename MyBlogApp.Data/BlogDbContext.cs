namespace MyBlogApp.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    /*
     Database �le iligili EntityFramework kullanarak i�lem yap�laca�� zaman 
     kullan�lcak Haz�r s�n�f�n ad� "xDbContext" ve bu s�n�f mutlaka  "DbContext" 'ten
     Miras almak zorunda 
     EntityFrameWork Temel database i�lemlerini yapabilmemiz i�in tan�mlad��� bir class var Bizde o clastan 
     Miras alarak Databasedeki tablolar�n Bir �rne�i olan Classlara eri�iyoruz 
    */


    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=BlogDbContext")
        {

        }

        //D��ardan gelen "ConnectionStringName" parametresi Base s�n�f�n Yap�c� metoduna aktar�l�r
        //A�a��daki Kullan�m �ekli base s�n�f�n konstructor'�n� aktif hale  getirir
        //Miras al�nanan s�n�f�n constructor metodu aktifle�tirilir
        //Yukar�da bulunan "BlogDbContext()" default olarak gelior bizde Kendimiz �stedi�imiz�ekilde
        //Birden fazla Constructor ekleyebiliriz
        public BlogDbContext(string ConnectionStringName) : base(ConnectionStringName)
        {

        }


        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Articles)
                .Map(m => m.ToTable("ArticleTag").MapLeftKey("ArticleId").MapRightKey("TagId"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UseerRole").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
