using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public interface IEvent
    {
        bool IsProcessed();

        List<object> GetResultEntries();

        void AddResultingEnteries();
    }
}
