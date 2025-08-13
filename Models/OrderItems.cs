using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProducts.Models;

public class OrdersItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public int ProductsId { get; set; }
    [ForeignKey("ProductsId")]
    public virtual Products? Product { get; set; }

    public int OrdersId { get; set; }
    [ForeignKey("OrdersId")]
    public virtual Orders? Order { get; set; }

}