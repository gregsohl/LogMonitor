﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Tail.Processors
{
    internal static class Helper
    {
        private static readonly Regex lineSplit = new Regex(@"\r\n|\r(?!\n)|(?<!\r)\n", RegexOptions.Compiled);

        public static string[] SplitLines(string content)
        {
            if (string.IsNullOrEmpty(content))
                return new string[0];

            return lineSplit.Split(content);
        }

        public static string ReadFile(string filename)
        {
            Stream stream = null;

            try
            {
                stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);


                using (StreamReader reader = new StreamReader(stream))
                {
                    stream = null;
                    
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }
    }
}
