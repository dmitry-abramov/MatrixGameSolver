using SimpleGameSolver.Experiments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleGameSolver
{
    public class DynamicResourceLoader
    {
        public static IList<BrownMethodBase> GetBrownMethodImplementations()
        {
            var methods = new List<BrownMethodBase>();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in GetFiles(path, "*.exe|*.dll", SearchOption.AllDirectories))
            {
                var assembly = Assembly.LoadFile(dll);
                var methodTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BrownMethodBase)) && !t.IsAbstract);

                foreach (var methodType in methodTypes)
                {
                    methods.Add((BrownMethodBase)Activator.CreateInstance(methodType));
                }
            }

            return methods;
        }

        public static IList<Experiment> GetExperiments()
        {
            var sources = new List<Experiment>();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in GetFiles(path, "*.exe|*.dll", SearchOption.AllDirectories))
            {
                var assembly = Assembly.LoadFile(dll);
                var sourceTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Experiment)) && !t.IsAbstract);

                foreach (var sourceType in sourceTypes)
                {
                    sources.Add((Experiment)Activator.CreateInstance(sourceType));
                }
            }

            return sources;
        }

        private static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            string[] searchPatterns = searchPattern.Split('|');            
            var files = new List<string>();
            
            foreach (string sp in searchPatterns)
            {
                files.AddRange(Directory.GetFiles(path, sp, searchOption));
            }

            files.Sort();

            return files.ToArray();
        }
    }
}
