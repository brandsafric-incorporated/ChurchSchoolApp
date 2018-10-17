namespace ChurchSchool.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public CourseConfiguration CurrentConfiguration { get; set; }
    }
}