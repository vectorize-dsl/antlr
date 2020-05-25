using System;
using System.IO;

namespace Vectorize.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var examplesDir = new DirectoryInfo("Examples");
            var interpreter = new Interpreter.Interpreter();
            foreach (var exmapleFile in examplesDir.GetFiles("*.vec"))
            {
                Console.Write($"Parsing file '{exmapleFile.Name}'...");
                var result = interpreter.Run(exmapleFile);

                if (result.Errors.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" DONE!");
                    Console.ResetColor();

                    var svgFile = Path.Join(
                        exmapleFile.DirectoryName,
                        Path.GetFileNameWithoutExtension(exmapleFile.Name) + ".svg"
                    );

                    File.WriteAllText(svgFile, result.Output);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" FAIL!");
                    Console.ResetColor();

                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }
    }
}
