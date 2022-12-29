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

    static ContaCorrente ConverteLinhaParaContaCorrente(string linha)
    {
        string[] campos = linha.Split(',');

        int agencia = int.Parse(campos[0]);
        int numeroConta = int.Parse(campos[1]);
        double saldo = double.Parse(campos[2].Replace('.', ','));

        var titular = new Cliente();
        string nome = campos[3];

        titular.Nome = nome;

        var contaAtual = new ContaCorrente(agencia, numeroConta);
        contaAtual.Depositar(saldo);
        contaAtual.Titular = titular;

        return contaAtual;
    }

    static void LendoArquivoCSV()
    {
        string enderecoArquivo = "D://Cursos/ByteBankIO-master/contas.txt";

        using (var fs = new FileStream(enderecoArquivo, FileMode.Open))
        {
            StreamReader leitor = new StreamReader(fs);

            //string linha = leitor.ReadLine();
            //string texto = leitor.ReadToEnd();

            while (!leitor.EndOfStream)
            {
                ContaCorrente contaCorrente = ConverteLinhaParaContaCorrente(leitor.ReadLine());
                string msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
    }

}