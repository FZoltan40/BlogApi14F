using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blogger> Bloggers { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=blog;user=root;password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blogger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("blogger");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.ModTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("modTime");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name");
            entity.Property(e => e.RegTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("regTime");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.HasIndex(e => e.Bloggerid, "bloggerid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bloggerid)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("bloggerid");
            entity.Property(e => e.ModTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("modTime");
            entity.Property(e => e.Post1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("post");
            entity.Property(e => e.RegTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("regTime");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("title");

            entity.HasOne(d => d.Blogger).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Bloggerid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("posts_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
