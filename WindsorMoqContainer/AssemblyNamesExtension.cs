using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestTools.WindsorMoqContainer
{
    internal static class AssemblyNamesExtension
    {
        /// <summary>
        /// Type is needed to determine the root Name of the
        /// assemblies containing the dependencies
        /// </summary>
        /// <param name="typeFromSolution"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetSolutionAssemblyNames(this Type typeFromSolution)
        {
            return Assembly.GetAssembly(typeFromSolution)
                           .GetAssemblyRootName()
                           .GetAssembliesNestedWithInRootAssemblyName();
        }

        /// <summary>
        /// scan through the base directory for file with '.dll' extensions,
        /// and starting with the name of the root assembly
        /// </summary>
        /// <param name="rootAssemblyName"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetAssembliesNestedWithInRootAssemblyName(this string rootAssemblyName)
        {
            return Directory.EnumerateFiles(
                                AppDomain.CurrentDomain.BaseDirectory,
                                "*.*", SearchOption.AllDirectories)
                            .Where(x =>
                                       Path.GetExtension(x)
                                           .Equals(".dll",
                                                   StringComparison.InvariantCultureIgnoreCase))
                            .Where(x => Path.GetFileName(x)
                                            .StartsWith(rootAssemblyName,
                                                        StringComparison.InvariantCultureIgnoreCase))
                            .Select(x => Path.GetFileName(x));
        }
        /// <summary>
        /// Gets the root assembly name,
        /// Eg. TestTools.WindsorMoqContainer, TestTools is the root name
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static string GetAssemblyRootName(this Assembly assembly)
        {
            var delimiterIndex = assembly.
                                 FullName.
                                 IndexOfAny(new[] { '.' });

            if (delimiterIndex < 0)
                throw new ArgumentException("No delimiter identified in the root name");

            return assembly
                   .FullName
                   .Substring(0, delimiterIndex);
        }

    }
}
