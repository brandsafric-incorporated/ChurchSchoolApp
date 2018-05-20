using System.ComponentModel;

namespace ChurchSchool.Domain.Enum
{
    /// <summary>
    /// Provides a domain for enrollment status 
    /// </summary>
    public enum EEnrollmentStatus
    {
        [Description("Não Definido")]
        UNDEFINED = 0,
        [Description("Ativo")]
        ACTIVE = 1,
        [Description("Suspenso")]
        SUSPEND = 2,
        [Description("Cancelado")]
        CANCELED = 3,
        [Description("Concluído")]
        COMPLETED = 4,
        [Description("Aguardando Aprovação")]
        WAITING_APROVEMENT = 5
    }
}
