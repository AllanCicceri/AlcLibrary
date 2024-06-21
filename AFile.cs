using System;
using System.IO;

namespace AlcLibrary
{
    public class AFile
    {
        private readonly string _name;
        private readonly string _currentDirectory;
        private readonly string _path;
        public AFile(string name)
        {
            _name = name;
            _currentDirectory = Directory.GetCurrentDirectory();
            _path = Path.Combine(_currentDirectory, name);
        }

        private void MakeFile()
        {
            if (!File.Exists(_path)) 
            {
                using(StreamWriter sw = File.CreateText(_path))
                {
                }
            }
              
        }

        public void WriteFile(string text)
        {
            MakeFile();
            using (StreamWriter sw = File.AppendText(_path))
            {
                DateTime date = DateTime.Now;
                sw.WriteLine($"{date.ToShortDateString()}:{text}");
            }

        }
        public string ReadFile() 
        {
            if (File.Exists(_path))
            {
                return File.ReadAllText(_path);
            }
            else { return ""; }
        }


    }
}
