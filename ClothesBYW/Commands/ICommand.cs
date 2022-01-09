using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesBYW.Commands
{
    public interface ICommand
    {
        void Execute();
        bool CanExcute(); // Điều kiện có thể thực thi lệnh
        void Undo();
    }
}
