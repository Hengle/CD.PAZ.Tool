using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Unpacker
{
    class Program
    {
        private static String m_Title = "Crimson Desert PAZ Unpacker";

        static void Main(String[] args)
        {
            Console.Title = m_Title;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(m_Title);
            Console.WriteLine("(c) 2026 Ekey (h4x0r) / v{0}\n", Utils.iGetApplicationVersion());
            Console.ResetColor();

            if (args.Length != 1 && args.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[Usage]");
                Console.WriteLine("    CD.Unpacker <m_File> <m_Directory>\n");
                Console.WriteLine("    m_File - Source of PAMT file");
                Console.WriteLine("    m_Directory - Destination directory (Optional)\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Examples]");
                Console.WriteLine("    CD.Unpacker E:\\Games\\CD\\0003\\0.pamt");
                Console.WriteLine("    CD.Unpacker E:\\Games\\CD\\0003\\0.pamt D:\\Unpacked");
                Console.ResetColor();
                return;
            }

            String m_MetaFile = args[0];
            String m_Output = Utils.iCheckArgumentsPath(args[0]);

            if (args.Length == 1)
            {
                m_Output = Path.GetDirectoryName(args[0]) + @"\" + Path.GetFileNameWithoutExtension(args[0]) + @"\";
            }
            else
            {
                m_Output = Utils.iCheckArgumentsPath(args[1]);
            }

            if (!File.Exists(m_MetaFile))
            {
                Utils.iSetError("[ERROR]: Input PAMT file -> " + m_MetaFile + " <- does not exist");
                return;
            }

            PazUnpack.iDoIt(m_MetaFile, m_Output);
        }
    }
}
