using ByteBankIO;
using System.Text;

partial class Program
{
    static void LendoArquivosDiretamenteComBuffers(string[] args)
    {
        string enderecoArquivo = "D://Cursos/ByteBankIO-master/contas.txt";


        using (FileStream fs = new FileStream(enderecoArquivo, FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            int numeroDeBytes = -1;

            while (numeroDeBytes != 0)
            {
                numeroDeBytes = fs.Read(buffer, 0, 1024);
                EscreverBuffer(buffer, numeroDeBytes);
            }

            fs.Close();
            Console.WriteLine();
        }

    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();
        string texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);
    }
}