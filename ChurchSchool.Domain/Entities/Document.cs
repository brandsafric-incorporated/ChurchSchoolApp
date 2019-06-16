using ChurchSchool.Domain.Enum;
using System;

namespace ChurchSchool.Domain.Entities
{
    public abstract class Document : BaseEntity
    {
        public int DocumentTypeId { get; set; }

        public string DocumentNumber { get; set; }

        /// <summary>
        /// Orgão emissor
        /// </summary>
        public string IssuingEntity { get; set; }

        /// <summary>
        /// Data de Emissão
        /// </summary>
        public DateTime IssuingDate { get; set; }

        /// <summary>
        /// Tipo de Documento
        /// </summary>
        public EDocumentType DocumentType
        {
            get
            {
                return (EDocumentType)this.DocumentTypeId;
            }
            set
            {
                this.DocumentTypeId = (int)value;
            }
        }
    }
}
