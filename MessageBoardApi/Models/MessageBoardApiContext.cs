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
          new Message { MessageId = 1, Comment = "I'm a good boy", Group = "Good Times", UserName = "mr_hans", Date = new DateTime(2023, 1, 29)},
          new Message { MessageId = 2, Comment = "Time is crazy", Group = "Good Times", UserName = "mr_hans", Date = new DateTime()},
          new Message { MessageId = 3, Comment = "I like time, i'm obsessed with it.", Group = "Good Times", UserName = "mr_hans", Date = new DateTime(2023, 1, 29, 18, 00, 21)}
          );
    }
  }
}