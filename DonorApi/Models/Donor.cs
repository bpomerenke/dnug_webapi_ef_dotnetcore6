using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonorApi.Models;

[Table("donors", Schema = "data")]
public class Donor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
}