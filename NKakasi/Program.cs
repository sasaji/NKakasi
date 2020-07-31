using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace NKakasi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Kakasi kakasi = new Kakasi();
                if (!kakasi.SetArguments(args))
                {
                    Usage();
                }
                else
                {
                    kakasi.Do();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        private static void Usage()
        {
            Console.Error.WriteLine(
                string.Format("KAKASI - Kanji Kana Simple Inverter  Version {0}",
                    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion));
            Console.Error.WriteLine();
            Console.Error.WriteLine("Usage: kakasi -K[aH] -H[aK] -J[aKH]");
            Console.Error.WriteLine("              [-i<input-encoding>] [-o<output-encoding>]");
            Console.Error.WriteLine("              [-p] [-f] [-c] [-s] [-b]");
            Console.Error.WriteLine("              [-r{hepburn | kunrei}] [-C | -U] [-w]");
            Console.Error.WriteLine("              [dictionary1 [dictionary2 [,,,]]]");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\tCharacter Set Conversions:");
            Console.Error.WriteLine("\t -JH: kanji to hiragana");
            Console.Error.WriteLine("\t -JK: kanji to katakana");
            Console.Error.WriteLine("\t -Ja: kanji to romaji");
            Console.Error.WriteLine("\t -HK: hiragana to katakana");
            Console.Error.WriteLine("\t -Ha: hiragana to romaji");
            Console.Error.WriteLine("\t -KH: katakana to hiragana");
            Console.Error.WriteLine("\t -Ka: katakana to romaji");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\tOptions:");
            Console.Error.WriteLine("\t -i: input encoding");
            Console.Error.WriteLine("\t -o: output encoding");
            Console.Error.WriteLine("\t -p: list all readings (with -J option)");
            Console.Error.WriteLine("\t -f: furigana mode (with -J option)");
            Console.Error.WriteLine("\t -c: skip whitespace chars within jukugo");
            Console.Error.WriteLine("\t -s: insert separate characters");
            Console.Error.WriteLine(
                "\t -b: output buffer is not flushed when a newline character is written");
            Console.Error.WriteLine("\t -r: romaji conversion system");
            Console.Error.WriteLine("\t -C: romaji Capitalize");
            Console.Error.WriteLine("\t -U: romaji Uppercase");
            Console.Error.WriteLine("\t -w: wakachigaki mode");
        }
    }
}
