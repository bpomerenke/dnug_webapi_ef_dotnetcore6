using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonorApi.Models;

[Table("designation", Schema = "data")]
public class Designation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("donor_id")]
    public int DonorId { get; set; }
    
    [Column("label")]
    public string Label { get; set; }
}