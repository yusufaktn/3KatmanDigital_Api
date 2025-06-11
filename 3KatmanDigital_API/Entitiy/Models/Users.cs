namespace Entitiy.Models
{
    public class Users:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  PasswordHash  { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Kullanıcı girişleri alınınca eklencek

    }
}
