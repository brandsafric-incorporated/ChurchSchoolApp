using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    public enum EDocumentType
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("CPF")]
        CPF = 1,
        [Description("RG")]
        RG = 2,
        [Description("Carteira de Trabalho")]
        CTPS = 3,
        [Description("Registro de Membro")]
        REGISTRO_MEMBRESIA = 4
    }
}