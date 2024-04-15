using System;
using System.Diagnostics;

namespace ReactStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false
            };

            using (var process = Process.Start(startInfo))
            {
                using (var sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        // Caminho para o diretório do seu aplicativo React
                        sw.WriteLine("cd C:\\Users\\italo\\source\\repos\\DotNet8Authentication\\DotNet8Authentication\\View\\frontend\\");

                        // Comando para iniciar o aplicativo React
                        sw.WriteLine("npm start");
                    }
                }
            }
        }
    }
}
