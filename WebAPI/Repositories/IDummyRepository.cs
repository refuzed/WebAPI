using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IDummyRepository
    {
        IEnumerable<Dummy> GetAll();
        Dummy Get(Guid id);
        Dummy Add(Dummy item);
        bool Update(Dummy dummy);
        bool Delete(Guid id);
    }
}