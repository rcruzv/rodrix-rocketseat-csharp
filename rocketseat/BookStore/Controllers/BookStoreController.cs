using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookStoreController : ControllerBase
{
    public static List<BookStoreModel> books = [];

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] BookStoreModel model)
    {
        model.Id = Guid.NewGuid();
        books.Add(model);
        return Created();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(BookStoreModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(Guid id, [FromBody] BookStoreModel model)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book == null)
            return NotFound();

        book.Title = model.Title;
        book.Author = model.Author;
        book.Genre = model.Genre;
        book.Price = model.Price;
        book.Stock = model.Stock;
        
        return Ok(book);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BookStoreModel>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookStoreModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BookStoreModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book == null)
            return NotFound();

        books.Remove(book);
        return Ok(book);
    }

}
