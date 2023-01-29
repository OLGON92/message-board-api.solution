namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Comment { get; set; }
    public string Group { get; set; }
    public string UserName { get; set; }
    public DateTime Date { get; set; }
  }
}