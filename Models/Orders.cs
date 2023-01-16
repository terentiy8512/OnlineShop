using System.ComponentModel.DataAnnotations;

public class Orders
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }
}