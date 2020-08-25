namespace Ninkovic.Stefan.CSharpToPlant.Business.File
{
    public class FileWriter
    {
        public bool CreateFile(string path, string text)
        {
            if (System.IO.File.Exists(path))
                return false;

            System.IO.File.WriteAllText(path, text);

            return System.IO.File.Exists(path);
        }
    }
}
