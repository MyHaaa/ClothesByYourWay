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
        public bool ChangeStatus(long id)
        {
            var feedback = db.Feedbacks.Find(id);
            feedback.Status = !feedback.Status;
            db.SaveChanges();
            return feedback.Status;
        }
    }
}
