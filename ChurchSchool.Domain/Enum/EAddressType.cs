using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    public enum EAddressType
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("Casa")]
        HOME = 1,
        [Description("Trabalho")]
        WORK = 2
    }
}
