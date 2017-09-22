using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Counter.DAL
{
    public interface ICounterDAL
    {
        Counter GetValue();
        void CreateData(Counter entity);
        void SaveData();
        Counter GetCurrentValue();
        int Increase();
    }
}
