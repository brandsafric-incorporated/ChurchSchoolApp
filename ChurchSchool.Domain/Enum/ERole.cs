using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    /// <summary>
    /// Provides a domain for enrollment status 
    /// </summary>
    public enum ERole
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("Professor")]
        TEACHER = 1,
        [Description("Estudante")]
        STUDENT = 2,
        [Description("Assistente")]
        ASSISTENT = 3,
        [Description("Gestor")]
        MANAGER = 4
    }
}