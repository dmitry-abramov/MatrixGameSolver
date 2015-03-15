using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleGameSolver
{
    public class ExperimentsSourceLoader
    {
        public static IList<ExperimentSourceBase> GetExperimentSources()
        {
            var sources = new List<ExperimentSourceBase>();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in GetFiles(path, "*.exe|*.dll", SearchOption.AllDirectories))
            {
                var assembly = Assembly.LoadFile(dll);
                var sourceTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ExperimentSourceBase)) && !t.IsAbstract);

                foreach (var sourceType in sourceTypes)
                {
                    sources.Add((ExperimentSourceBase)Activator.CreateInstance(sourceType));
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
