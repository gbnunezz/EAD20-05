using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        bool sair = false;
        Produto p = new Produto(); // Criar uma única instância

        while (!sair)
        {
            Console.Write(" [1] cadastrar produto \n [2] atualizar estoque \n [3] listar produtos \n [4] listar por quantidade \n [5] sair \n insira a opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    p.Cadastrar();
                    await Task.Delay(500);
                    break;

                case 2:
                    Console.Write("qual produto deseja atualizar o estoque: ");
                    string nome = Console.ReadLine();

                    Console.Write("insira a quantidade: ");
                    int q = int.Parse(Console.ReadLine());
                    p.Atualizar(nome, q);
                    await Task.Delay(500);
                    break;

                case 3:
                    p.Listar();
                    await Task.Delay(5000); 
                    break;

                case 4:
                    Console.Write("insira a quantidade mínima: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    p.ListarPorQuantidade(quantidade);
                    await Task.Delay(5000); 
                    break;

                case 5:
                    sair = true; 
                    await Task.Delay(500);
                    break;

                default:
                    Console.WriteLine("opção inválida");
                    await Task.Delay(500);
                    break;
            }

            Console.Clear();
        }
    }
}
