using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Customer
{
    public class FeedbackDao
    {
        private ClothesBYWDbContext db = null;
        public FeedbackDao()
        {
            db = new ClothesBYWDbContext();
        }
        public List<Feedback> GetFeedbacks() => db.Feedbacks.ToList();
        public bool UploadFeedback(string customerID, string productID, int star, string title, string content)
        {
            db.Feedbacks.Add(new Feedback()
            {
                CustomerID = customerID,
                ProductID = productID,
                Star = star,
                Title = title,
                Content = content,
                CreateDate = DateTime.Now
            });
            db.SaveChanges();
            return true;
        }
    }
}
