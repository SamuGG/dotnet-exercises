using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Creating \"Blogging\" database");
using var dbContext = new BloggingContext();

Console.WriteLine("Creating a blog with some posts");
var newBlog = new BlogEntity
{
    Url = new Uri("http://blogging.com/001"),
    Posts = new List<PostEntity>
    {
        new() { Title = "My first post", Content = "Welcome to my blog" },
        new() { Title = "Article1", Content = "The content for first article" },
        new() { Title = "Article2", Content = "Another article with some content" }
    }
};

Console.WriteLine("Inserting new blog entity");
await dbContext.Blogs.AddAsync(newBlog).ConfigureAwait(false);
await dbContext.SaveChangesAsync().ConfigureAwait(false);

Console.WriteLine("Retrieving last post entity");
var postEntity = await dbContext.Posts.LastOrDefaultAsync().ConfigureAwait(false);

if (postEntity is not null)
{
    Console.WriteLine("Updating the post content");
    postEntity.Content = "Updated content for last post";
    await dbContext.SaveChangesAsync().ConfigureAwait(false);
}
else
{
    Console.WriteLine("Post entity not found");
}

Console.WriteLine("Retrieving first blog");
var blogEntity = await dbContext.Blogs
    .Include(blog => blog.Posts)
    .FirstOrDefaultAsync()
    .ConfigureAwait(false);

if (blogEntity is not null)
{
    Console.WriteLine($"Url: {blogEntity.Url}");
    Console.WriteLine($"Posts: {string.Join(", ", blogEntity.Posts.Select(p => p.Title))}");

    Console.WriteLine("Deleting blog's last post");
    postEntity = blogEntity.Posts.LastOrDefault();
    if (postEntity is not null)
    {
        blogEntity.Posts.Remove(postEntity);
        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
    Console.WriteLine($"Posts: {blogEntity.Posts.Count}");
}
else
{
    Console.WriteLine("Blog entity not found");
}


internal sealed class BloggingContext : DbContext
{
    public DbSet<BlogEntity> Blogs { get; set; } = null!;
    public DbSet<PostEntity> Posts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("Blogging");
    }
}

[Table("Blogs")]
internal sealed class BlogEntity
{
    [Key]
    public int BlogId { get; set; }

    [Required]
    public Uri Url { get; set; } = null!;

    public ICollection<PostEntity> Posts { get; set; } = Array.Empty<PostEntity>();
}

[Table("Posts")]
internal sealed class PostEntity
{
    [Key]
    public int PostId { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;

    public int BlogId { get; set; }
    public BlogEntity Blog { get; set; } = null!;
}