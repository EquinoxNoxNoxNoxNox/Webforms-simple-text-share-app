namespace Notebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class DataAccess : DbContext
    {
        // Your context has been configured to use a 'Notebook' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Notebook.Models.Notebook' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Notebook' 
        // connection string in the application configuration file.
        public DataAccess()
            : base("name=Notebook")
        {
        }
        /// <summary>
        /// جدول نوشته ها
        /// </summary>
        public DbSet<M_Note> Notes { get; set; }
        /// <summary>
        /// جدول کاربر ها
        /// </summary>
        public DbSet<M_User> Users { get; set; }
        /// <summary>
        /// تعداد لایک هر پست
        /// </summary>
        public DbSet<M_NoteLike> NoteLike { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_Note>()
            .HasRequired<M_User>(s => s.Author)
            .WithMany(x => x.Notes)
            .HasForeignKey<int>(z => z.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
    /// <summary>
    /// تعداد دفعات لایک هر پست
    /// </summary>
    public class M_NoteLike
    {
        /// <summary>
        /// شناسه ی پست لایک
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// آیدی نوشته
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// آیدی یوزر
        /// </summary>
        public int UserId { get; set; }
    }
    /// <summary>
    /// مدل جدول نوشته ها
    /// </summary>
    public class M_Note
    {
        public M_Note()
        {
            CreateDate = DateTime.Now;
        }
        /// <summary>
        /// شناسه ی نوشته
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// عنوان نوشته
        /// </summary>
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        /// <summary>
        /// محتوای نوشته
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        /// <summary>
        /// تاریخ ایجاد شده
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// شناسه ی نویسنده
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// نویسنده
        /// </summary>

        public virtual M_User Author { get; set; }
    }
    public class M_User
    {
        /// <summary>
        /// شناسه ی جدول کاربر
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        /// <summary>
        /// رمز عبور
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
        /// <summary>
        /// نوشته های کاربر
        /// </summary>
        public virtual ICollection<M_Note> Notes { get; set; }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}