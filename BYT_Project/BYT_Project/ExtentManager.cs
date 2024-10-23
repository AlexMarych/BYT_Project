using Newtonsoft.Json;

namespace BYT_Project
{
    public class ExtentManager
    {
        private static readonly string FULL_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Resources\ClassExtent\");

        public static void SaveExtent<T>(List<T> extent)
        {
            if (extent is null)
                return;

            var employeeExtentString = JsonConvert.SerializeObject(extent);

            var path = Path.Combine(FULL_PATH, $"{extent[0].GetType()}.json");

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (FileStream fs = File.Create(path))
            {
                using (StreamWriter writer = new(fs))
                {
                    writer.Write(employeeExtentString);
                }
            }
        }
    }
}