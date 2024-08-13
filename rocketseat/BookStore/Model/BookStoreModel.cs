namespace BookStore.Model;

public class BookStoreModel
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

}
