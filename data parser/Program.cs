using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    class Program
    {
    
        public void remove_dup_in_csv_file(string path)
        {
            Dictionary<string, bool> lines = new Dictionary<string, bool>();
            var list = File.ReadLines(path);
            var keep = new List<string>();

            foreach(var item in list)
            {
                var key = item.Split(',')[0];
                if (lines.ContainsKey(key) == false)
                {
                    keep.Add(item);
                    lines.Add(key, true);
                }
            }

            Directory.CreateDirectory("data/");
            File.WriteAllLines("data/" + path, keep.ToArray());
            File.Delete(path);
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            var files_in_dir = Directory.GetFiles(".");
            foreach(var file in files_in_dir)
            {
                var list = file.Split('.');
                if (list[1] == "\\exporteddata")
                {
                    prog.remove_dup_in_csv_file(file);
                }
            }
        }
    }
}
