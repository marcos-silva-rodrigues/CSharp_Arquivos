using System;
using System.Text;

partial class Program {

    static void CriarArquivoComBuffer()
    {
        var caminhoNovoArquivo = "contaExportadas.csv";

        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            string contaString = "456, 7895, 4785.40, Gustavo Santos";

            var encoding = Encoding.UTF8;

            byte[] bytes = encoding.GetBytes(contaString);

            fs.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComStream()
    {
        var caminhoNovoArquivo = "contaExportadas.csv";

        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using(StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write("456,7895,4785.40,Gustavo Santos");
        }
    }

    static void TestaArquivo()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < 1000000; i++)
            {
                sw.WriteLine($"Linha {i}");
                sw.Flush();
                Console.WriteLine($"Linha {i} foi escrita, Tecle enter ...");
                Console.ReadLine();
            }
        }
    }
}
