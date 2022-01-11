using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class FeedbackDao
    {
        private ClothesBYWDbContext db = null;

        public FeedbackDao()
        {
            db = new ClothesBYWDbContext();
        }
        public bool ChangeStatus(string id)
        {
            var employee = db.Feedbacks.Find(id);
            employee.Status = !employee.Status;
            db.SaveChanges();
            return employee.Status;
        }
    }
}
