using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Counter.Services
{
    public interface ICounterService
    {
        Counter GetCurrentValue();
        int Increase();
    }
}
