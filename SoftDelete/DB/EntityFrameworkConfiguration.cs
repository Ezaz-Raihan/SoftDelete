using SoftDelete.Models.EFHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoftDelete.DB
{
    /// <summary>
    /// Have to put this class in the same assembly as DBContext and EF will load this config automatically
    /// </summary>
    public class EntityFrameworkConfiguration : DbConfiguration
    {
        public EntityFrameworkConfiguration()
        {
            AddInterceptor(new SoftDeleteInterceptor());
        }
    }
}