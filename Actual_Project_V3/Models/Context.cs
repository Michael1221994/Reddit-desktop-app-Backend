using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Actual_Project_V3.Models
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Save> Saves { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Subreddit> Subreddits { get; set; }
        public DbSet<JoinedSubreddits>  JoinedSubreddits { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UpvoteDownvote> UpvoteDownvote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

                modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            //configure relationship between user and Joined subreddits

            modelBuilder.Entity<User>()
                .HasMany(u => u.JoinedSubreddits)
                .WithOne(j => j.user)
                .HasForeignKey(j => j.User_Id);

            //configure relationship between subreddit and Joined subreddits
            modelBuilder.Entity<Subreddit>()
                .HasMany(s => s.JoinedSubreddits)
                .WithOne(j => j.subreddit)
                .HasForeignKey(j => j.sub_id);

            // Configure the one-to-many relationship between User and Post
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.User_Id)
                .OnDelete(DeleteBehavior.NoAction);


            // Configure the one-to-many relationship between User and Subreddit
            modelBuilder.Entity<User>()
                .HasMany(u => u.Subreddits)
                .WithOne(s => s.OwnerUser)
                .HasForeignKey(s => s.User_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure the one-to-many relationship between User and Comments
            modelBuilder.Entity<User>()
                .HasMany(s => s.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.User_Id)                
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between User and UpvoteDownvotes
            modelBuilder.Entity<User>()
                .HasMany(s => s.UpvoteDownvotes)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.User_Id)
                .OnDelete(DeleteBehavior.NoAction);

            //// Configure the one-to-many relationship between User and History
            //modelBuilder.Entity<User>()
            //    .HasMany(s => s.History)
            //    .WithOne(p => p.User)
            //    .HasForeignKey(p => p.User_Id)
            //    .OnDelete(DeleteBehavior.NoAction);

            //// Configure the one-to-many relationship between User and save
            //modelBuilder.Entity<User>()
            //    .HasMany(s => s.saves)
            //    .WithOne(p => p.User)
            //    .HasForeignKey(p => p.User_Id)
            //    .OnDelete(DeleteBehavior.NoAction);

            //History as a join table between user and posts
            modelBuilder.Entity<History>()
                .HasKey(h => new { h.User_Id, h.Post_Id });

            modelBuilder.Entity<History>()
                .HasOne(h => h.User)
                .WithMany(u => u.History)
                .HasForeignKey(h => h.User_Id);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Posts)
                .WithMany(p => p.History)
                .HasForeignKey(h => h.Post_Id);

            //History as a join table between user and save
            modelBuilder.Entity<Save>()
                .HasKey(h => new { h.User_Id, h.Post_Id });

            modelBuilder.Entity<Save>()
                .HasOne(h => h.User)
                .WithMany(u => u.saves)
                .HasForeignKey(h => h.User_Id);

            modelBuilder.Entity<Save>()
                .HasOne(h => h.Posts)
                .WithMany(p => p.saves)
                .HasForeignKey(h => h.Post_Id);

            // Configure the one-to-many relationship between Subreddit and Post
            modelBuilder.Entity<Subreddit>()
                .HasMany(s => s.Posts)
                .WithOne(p => p.Subreddit)
                .HasForeignKey(p => p.Sub_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between Subreddit and Comment
            modelBuilder.Entity<Subreddit>()
                .HasMany(s => s.Comments)
                .WithOne(p => p.Subreddit)
                .HasForeignKey(p => p.Sub_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between Post and comments
            modelBuilder.Entity<Post>()
                .HasMany(s => s.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.Post_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure the one-to-many relationship between Post and UpvoteDownvote
            modelBuilder.Entity<Post>()
                .HasMany(s => s.UpvoteDownvotes)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.Post_Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);//was no action


            // Configure the one-to-many relationship between comments and UpvoteDownvote
            modelBuilder.Entity<Comment>()
                .HasMany(s => s.UpvoteDownvotes)
                .WithOne(p => p.Comments)
                .HasForeignKey(p => p.Comment_Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);//was no action

            


            base.OnModelCreating(modelBuilder);
        }


    }
}

