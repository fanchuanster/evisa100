using EVisa100.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVisa100.Automations
{
    interface IAutomation
    {
        bool Run(Application application);
    }
}
