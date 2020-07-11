using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NKakasi
{
    class ItaijiDictionary
    {
        private readonly Dictionary<Character, Character> table = new Dictionary<Character, Character>();

        internal static ItaijiDictionary GetInstance()
        {
            return new ItaijiDictionary();
        }

        private ItaijiDictionary()
        {
            try
            {
                Initialize();
            }
            catch (IOException exception)
            {
                Console.Error.WriteLine(exception.StackTrace);
            }
        }

        private void Initialize()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "itaijidict");
            if (!File.Exists(path))
                path = Environment.GetEnvironmentVariable("ITAIJIDICTPATH");
            if (!File.Exists(path)) return;
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                StreamReader reader = new StreamReader(stream);
                try
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        line = line.Trim();
                        if (line.Length == 0)
                        {
                            continue;
                        }
                        if (line.Length != 2)
                        {
                            Console.Error.WriteLine("ItaijiDictionary: Ignored line: " + line);
                        }
                        table.Add(new Character(line[0]), new Character(line[1]));
                    }
                }
                finally
                {
                    try
                    {
                        reader.Close();
                        stream = null;
                    }
                    catch (IOException exception)
                    {
                        Console.Error.WriteLine(exception.StackTrace);
                    }
                }
            }
            finally
            {
                if (stream != null)
                {
                    try
                    {
                        stream.Close();
                    }
                    catch (IOException exception)
                    {
                        Console.Error.WriteLine(exception.StackTrace);
                    }
                }
            }
        }

        internal char Get(char ch)
        {
            return table.ContainsKey(new Character(ch)) ? table[new Character(ch)].Value : ch;
        }
    }
}
