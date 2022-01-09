using ClothesBYW.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesBYW.Subjects
{
    public interface IResignation
    {
        void AddObserver(IResignationObserver observer);
        void RemoveObserver(IResignationObserver observer);
        void NotifyObserver(string purchaseOrderID);

    }
}
