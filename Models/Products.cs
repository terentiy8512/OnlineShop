using System.ComponentModel.DataAnnotations;

public class Products
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }

}