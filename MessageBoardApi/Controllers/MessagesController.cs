using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace MessageBoardApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public MessagesController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [MapToApiVersion("2.0")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string comment, string group, string userName)
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
      return await query.ToListAsync();
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

    /*[HttpPatch("{id}")]//probably need to make this look more like the put request above.
    public async Task<IActionResult> Patch(int id, Message message)
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
    }*/
    
    // DELETE: api/Messages/5
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