using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    public enum ESex
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("Masculino")]
        MALE = 1,
        [Description("Feminino")]
        FEMALE = 2,
    }
}
