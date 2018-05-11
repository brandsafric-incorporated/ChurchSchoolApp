using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public abstract class Document : BaseEntity
    {
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Orgão emissor
        /// </summary>
        public string IssuingEntity { get; set; }

        /// <summary>
        /// Data de Emissão
        /// </summary>
        public DateTime IssuingDate { get; set; }

        public EDocumentType DocumentTypeId { get; set; }
    }
}
