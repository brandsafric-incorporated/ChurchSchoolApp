namespace ChurchSchool.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Person User { get; set; }
    }
}
