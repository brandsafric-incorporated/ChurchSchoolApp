using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    public enum Sex
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("Masculino")]
        MALE = 1,
        [Description("Feminino")]
        FEMALE = 2,
    }
}
