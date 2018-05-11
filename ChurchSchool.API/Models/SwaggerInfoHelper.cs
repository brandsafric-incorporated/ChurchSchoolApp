using Swashbuckle.AspNetCore.Swagger;

namespace ChurchSchool.API.Models
{
    public class SwaggerInfoHelper
    {
        public static Info GetSwaggerInformation()
        {
            return new Info
            {
                Title = "API - Seminário da Igreja de Deus no Brasil - Petrópolis",
                Version = "1.0",
                Contact = new Contact
                {
                    Name = "Henrique Ferreira"
                },
                Description = "Api com dados educacionais e administrativos do seminário da Igreja de Deus no Brasil - Petrópolis"
            };
        }
    }
}
