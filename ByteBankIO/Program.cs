using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        string enderecoArquivo = "D://Cursos/ByteBankIO-master/contas.txt";

        using (var fs = new FileStream(enderecoArquivo, FileMode.Open))
        {
            StreamReader leitor = new StreamReader(fs);

            //string linha = leitor.ReadLine();
            //string texto = leitor.ReadToEnd();

            while(!leitor.EndOfStream)
            {
                Console.WriteLine(leitor.ReadLine());
            }
        }

    }

}