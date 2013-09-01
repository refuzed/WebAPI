using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class DummyRepository : IDummyRepository
    {
        private Dictionary<Guid, Dummy> _dummies = new Dictionary<Guid, Dummy>();

        public DummyRepository()
        {
            Guid guid = Guid.NewGuid();
            _dummies.Add(guid, new Dummy { Id = guid, Name= "Item 1", Value = "Some value" });

            guid = Guid.NewGuid();
            _dummies.Add(guid, new Dummy { Id = guid, Name = "Item 2", Value = "Some other value" });


            guid = Guid.NewGuid();
            _dummies.Add(guid, new Dummy { Id = guid, Name = "Item 3", Value = "Something something darkside" });
        }

        public IEnumerable<Dummy> GetAll()
        {
            foreach (var dummy in _dummies)
                yield return dummy.Value;
        }

        public Dummy Get(Guid id)
        {
            Dummy result;
            _dummies.TryGetValue(id, out result);
            return result;
        }

        public Dummy Add(Dummy dummy)
        {
            if (dummy == null) { throw new ArgumentNullException("dummy"); }

            var guid = Guid.NewGuid();
            dummy.Id = guid;
            _dummies.Add(guid, dummy);

            return dummy;
        }

        public bool Update(Dummy dummy)
        {
            if (dummy == null) { throw new ArgumentNullException("dummy"); }

            if(!_dummies.ContainsKey(dummy.Id))
                return false;

            _dummies[dummy.Id] = dummy;
            return true;
        }

        public bool Delete(Guid id)
        {
            if (!_dummies.ContainsKey(id))
                return false;

            _dummies.Remove(id);
            return true;
        }
    }
}
