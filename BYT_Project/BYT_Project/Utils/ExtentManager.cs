using Newtonsoft.Json;
using System.IO;

namespace BYT_Project.Utils
{
    public class ExtentManager
    {
        private static readonly string FULL_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Resources\ClassExtent\");

        private static JsonSerializerSettings _settings => new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        public static void SaveExtent<T>(List<T> extent)
        {
            if (extent is null || extent.Count == 0)
                return;

            var employeeExtentString = JsonConvert.SerializeObject(extent, _settings);

            var path = Path.Combine(FULL_PATH, $"{extent[0].GetType()}.json");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("directory dosn't exist");
                return;
            }


            using (FileStream fs = File.Create(path))
            {
                using (StreamWriter writer = new(fs))
                {
                    writer.Write(employeeExtentString);
                }
            }
        }

        public static void ReadExtent<T>()
        {
            var list = LoadExtent<T>();

            if (list != null && list.Count > 0)
                list.ForEach(x => Console.WriteLine(x));
            else
                Console.WriteLine($"The class extent is empty.");
        }

        public static List<T> LoadExtent<T>()
        {
            var path = Path.Combine(FULL_PATH, $"{typeof(T)}.json");

            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<T>>(file, _settings);

                if (list != null && list.Count > 0)
                    return list;
            }

            return [];
        }

        public static void ClearExtent<T>()
        {
            var path = Path.Combine(FULL_PATH, $"{typeof(T)}.json");

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}