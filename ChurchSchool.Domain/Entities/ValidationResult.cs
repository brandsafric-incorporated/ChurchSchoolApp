using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class ValidationResult
    {
        private List<Error> _errors;
        
        public ValidationResult()
        {
            _errors = new List<Error>();
        }

        [NotMapped]
        public IList<Error> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value as List<Error>;
            }
        }

        public void AddError(string errorMessage)
        {
            AddError(new Error { Message = errorMessage });
        }

        public void AddError(params Error[] error)
        {
            _errors.AddRange(error);
        }

        public static ValidationResult GetEmptyResult()
        {
            return new ValidationResult();
        }
    }
}
