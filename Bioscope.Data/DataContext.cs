using System;
using System.Security.Cryptography;
using System.Text;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<AuthLog> AuthLogs { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Feature> Features { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<PostCategory> PostCategories { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RoleFeature> RoleFeatures { get; set; }
    public virtual DbSet<Staff> Staffs { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Upload>  Uploads {get; set;}
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasIndex(u => new { u.Email, u.UserName }).IsUnique();
      builder.Entity<User>().HasMany(u => u.Posts).WithOne(u => u.CreatedBy);

      // #region RoleSeed
      // builder.Entity<Role>().HasData(
      //   new Role() { Id = 1, Name = "Superadmin", AuthLevel = 0, Status = Status.Authorized },
      //   new Role() { Id = 2, Name = "Admin", AuthLevel = 0, Status = Status.Authorized },
      //   new Role() { Id = 3, Name = "User", AuthLevel = 0, Status = Status.Authorized }
      // );
      // #endregion

      // #region UserSeed
      // var hmac = new HMACSHA512 ();
      // byte[]  passwordSalt = hmac.Key;
      // byte[]  passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456"));

      // builder.Entity<User>().HasData(
      //   new User(){
      //     Id = 1,
      //     UserName = "superadmin",
      //     Email = "superadmin@bioscope.com",
      //     RoleId = 1,
      //     FirstName = "Super",
      //     LastName = "Admin",
      //     PasswordHash = passwordHash,
      //     PasswordSalt = passwordSalt,
      //     IsVerified = true,
      //     Status = Status.Authorized,
      //   }
      // );
      // #endregion
    }
  }
}