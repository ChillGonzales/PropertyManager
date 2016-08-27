using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Concrete
{
    public class EFWaitList : IWaitList
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<WaitListItem> WaitList
        {
            get { return context.WaitList; }
        }

        public PreUserResponseCode Add(WaitListItem item)
        {
            item.SignUpTS = DateTime.Now;
            context.WaitList.Add(item);
            context.SaveChanges();
            return PreUserResponseCode.Success;
        }
    }
}
