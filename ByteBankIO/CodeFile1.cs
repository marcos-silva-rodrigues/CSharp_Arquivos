using System;

partial class Program
{
    static void UsarStreamDeEstrada()
    {
        using(var fsConsole = Console.OpenStandardInput())
        using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024];
            while (true)
            {
                var bytesLidos = fsConsole.Read(buffer, 0, 1024);

                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();

                Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
            }
        }
    }
}