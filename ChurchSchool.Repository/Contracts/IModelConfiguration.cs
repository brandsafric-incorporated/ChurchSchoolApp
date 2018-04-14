using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IModelConfiguration
    {
        void Configure(ModelBuilder builder);
    }
}
