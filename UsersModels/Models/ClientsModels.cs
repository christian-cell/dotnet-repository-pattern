namespace UsersModels.Models;

public class Client
{
    public int UserId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Gender {get; set;}
    public bool Active {get; set;}

    /* creamos un constructor para no hacer las propiedades nullables */
    public Client()
    {
        if(FirstName == null)
        {
            FirstName = "";
        };
        if(LastName == null)
        {
            LastName = "";
        };
        if(Email == null)
        {
            Email = "";
        };
        if(Gender == null)
        {
            Gender = "";
        };
    }
}