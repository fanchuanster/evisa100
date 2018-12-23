using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVisa100.Automations
{
    static class AutomationsFactory
    {
        static Dictionary<string, Type> codeToAutomation;

        static AutomationsFactory()
        {
            Register<KenyaAutomation>("ke");
        }

        public static void Register<T>(string countryCode)
        {
            if (codeToAutomation == null)
                codeToAutomation = new Dictionary<string, Type>();

            codeToAutomation.Add(countryCode, typeof(T));
        }
        public static IAutomation GetAutomation(string countryCode)
        {
            Type type;
            if (codeToAutomation.TryGetValue(countryCode, out type))
            {
                return (IAutomation)Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
