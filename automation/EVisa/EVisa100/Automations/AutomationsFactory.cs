using System;
using System.Collections.Generic;

namespace EVisa100.Automations
{
    static class AutomationsFactory
    {
        static Dictionary<string, Type> codeToAutomation;

        static AutomationsFactory()
        {
            Register<KenyaAutomation>("ke");
            Register<ThailandAutomation>("tl");
            Register<PakistanAutomation>("pak");
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
