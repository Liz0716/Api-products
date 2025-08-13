using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProducts.Models;

public class Auth
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public string? Token { get; set; }
    public string? TokenExpiration { get; set; }

    public int UserId { get; set; }
   
    [ForeignKey("UserId")]
    public virtual Users? User { get; set; }
    
 
}