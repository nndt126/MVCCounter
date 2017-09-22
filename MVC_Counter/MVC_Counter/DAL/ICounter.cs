using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Counter.DAL
{
    public interface ICounter
    {
        Counter GetFirstValue();
        void Add(Counter entity);
        void Save();
        Counter GetCurrentValue();
        int IncreaseValue();
    }
}
