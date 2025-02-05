using System.Linq;
using System.IO;

namespace MapRenamer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mapFiles = Directory.GetFiles(".", "*.map");

            foreach (string mapFile in mapFiles)
            {
                string[] nameParts = Path.GetFileName(mapFile).Split('_');
                if (nameParts.Length > 1)
                {
                    string originalName = string.Join("_", nameParts.Take(nameParts.Length - 1)) + ".map";
                    string destPath = Path.Combine("..", "maps", originalName);

                    File.Copy(mapFile, destPath, true);
                }
            }
        }
    }
}