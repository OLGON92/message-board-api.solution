using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace MessageBoardApi.Controllers.v2
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public MessagesController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string comment, string group, string userName, int pageNumber = 1, int pageSize = 5)//pageNUmber to specific what page, and amount per page
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      if (comment != null)
      {
        query = query.Where(entry => entry.Comment == comment);
      }

      if (group != null)
      {
        query = query.Where(entry => entry.Group == group);
      }

      if (userName != null)
      {
        query = query.Where(entry => entry.UserName == userName);
      }
      int skip = (pageNumber - 1) * pageSize;
      // this line adds a page number and the number of messages per page
      return await query.Skip(skip).Take(pageSize).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }
      
      return message;
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    //PUT: api/Messages/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Messages.Update(message);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}

//https://localhost:1991/api/v2/messages?pageNumber=2&pageSize=5 by adding '?' and defining the pagenumber and size you will be going to next page