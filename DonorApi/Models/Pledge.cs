using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonorApi.Models;


[Table("pledges", Schema = "data")]
public class Pledge
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("donor_id")]
    public int DonorId { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }
    
    [Column("date")]
    public DateTimeOffset Date { get; set; }
    
    public virtual Donor Donor { get; set; }
}