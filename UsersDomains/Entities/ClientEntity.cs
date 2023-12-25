namespace UsersDomains.Entities;

public class ClientEntity
{
    public int UserId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Gender {get; set;}
    public string Address {get; set;}
    public bool Active {get; set;}
}