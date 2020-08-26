namespace Ninkovic.Stefan.CSharpToPlant.Business.File
{
    public class FileWriter
    {
        /// <summary>
        /// Creates a file in the given directory with the given text
        /// </summary>
        /// <param name="path">Path to create the file in</param>
        /// <param name="text">Content of the file to create</param>
        /// <returns>Identicates whether the file was created or not</returns>
        public bool CreateFile(string path, string text)
        {
            if (System.IO.File.Exists(path))
                return false;

            System.IO.File.WriteAllText(path, text);

            return System.IO.File.Exists(path);
        }
    }
}
