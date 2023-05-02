namespace Contato.Models
{
    public class ContatoModel
    {
        
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Phone { get; set; }   
        public string imageUser { get; set; }

        public ContatoModel(string Name, string Email, string Phone, string imageUser) { 
        this.Name = Name;
        this.Email = Email;
        this.Phone = Phone;
        this.imageUser = imageUser;

        }
    }
}
