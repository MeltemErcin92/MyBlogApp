namespace MyBlogApp.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    /*
     Database Ýle iligili EntityFramework kullanarak iþlem yapýlacaðý zaman 
     kullanýlcak Hazýr sýnýfýn adý "xDbContext" ve bu sýnýf mutlaka  "DbContext" 'ten
     Miras almak zorunda 
     EntityFrameWork Temel database iþlemlerini yapabilmemiz için tanýmladýðý bir class var Bizde o clastan 
     Miras alarak Databasedeki tablolarýn Bir Örneði olan Classlara eriþiyoruz 
    */


    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=BlogDbContext")
        {

        }

        //Dýþardan gelen "ConnectionStringName" parametresi Base sýnýfýn Yapýcý metoduna aktarýlýr
        //Aþaðýdaki Kullaným þekli base sýnýfýn konstructor'ýný aktif hale  getirir
        //Miras alýnanan sýnýfýn constructor metodu aktifleþtirilir
        //Yukarýda bulunan "BlogDbContext()" default olarak gelior bizde Kendimiz Ýstediðimizþekilde
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
