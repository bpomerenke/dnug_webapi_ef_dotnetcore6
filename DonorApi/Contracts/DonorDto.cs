namespace DonorApi.Contracts;

public class DonorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string AdditionalInfo { get; set; }
    
    public int Result { get; set; }
    public int Amount { get; set; }
}