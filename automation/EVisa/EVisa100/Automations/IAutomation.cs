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

    public abstract class Automation : IAutomation
    {
        public bool Run(Application application)
        {
            try
            {
                Execute(application);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        protected abstract void Execute(Application application);
    }
}
