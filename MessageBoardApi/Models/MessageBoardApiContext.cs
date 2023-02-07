using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Models
{
  public class MessageBoardApiContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }

    public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 35, Comment = "I'm a good boy", Group = "Good Times", UserName = "mr_hans", Date = DateTime.Now},
          new Message { MessageId = 36, Comment = "Time is crazy", Group = "Good Times", UserName = "mr_hans", Date = DateTime.Now},
          new Message { MessageId = 37, Comment = "I like time, i'm obsessed with it.", Group = "Good Times", UserName = "mr_hans", Date = DateTime.Now}
          );
    }
  }
}