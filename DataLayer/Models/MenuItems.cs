using System.ComponentModel.DataAnnotations;

namespace HMS_SAAS.DataLayer.Models;

public class MenuItems
{
    [Key]
    public string ItemId { get; set; } // m, s, b
    public string ItemName { get; set; } 
    public string Category { get; set; }
    public decimal PricePerUnit { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
