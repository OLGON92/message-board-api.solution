using System.ComponentModel.DataAnnotations;

namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(250, ErrorMessage = "You must enter a comment!")]
    public string Comment { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "You must enter a group name! Or suffer the consequences!")]
    public string Group { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "Enter a username or you're gonna catch deez hands!")]
    public string UserName { get; set; }
    public DateTime Date { get; set; }
  }
}