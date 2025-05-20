using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Produto
{
    protected int quantidade;
    protected string nome;
    private Dictionary<string, int> produtos = new Dictionary<string, int>();

    public bool Cadastrar()
    {
        try
        {
            Console.Write("Insira o nome: ");
            nome = Console.ReadLine();

            Console.Write("Insira a quantidade: ");
            quantidade = int.Parse(Console.ReadLine());

            if (produtos.ContainsKey(nome))
            {
                throw new Exception("Produto já existe no sistema.");
            }

            produtos.Add(nome, quantidade);
            return true;
        }
        catch (Exception error)
        {
            Console.WriteLine("Erro: " + error.Message);
            return false;
        }
    }

    public bool Atualizar(string nomeProduto, int num)
    {
        try
        {
            if (!produtos.ContainsKey(nomeProduto))
            {
                throw new Exception("Produto não encontrado.");
            }

            Console.Write("Deseja adicionar? (s/n): ");
            string op = Console.ReadLine().ToLower();

            if (op == "s")
            {
                produtos[nomeProduto] += num;
                return true;
            }
            else if (op == "n")
            {
                if (num > produtos[nomeProduto])
                {
                    throw new Exception("O estoque não possui essa quantidade.");
                }

                produtos[nomeProduto] -= num;
                return true;
            }
            else
            {
                throw new Exception("Opção inválida.");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Erro: " + error.Message);
            return false;
        }
    }

    public void Listar()
    {
        Console.WriteLine("Produtos cadastrados:");
        foreach (var item in produtos)
        {
            Console.WriteLine($"- {item.Key} | {item.Value} unidades");
        }

    }

    public void ListarPorQuantidade(int q)
    {
        Console.WriteLine($"Produtos com estoque igual ou abaixo de {q}:");

        foreach (var item in produtos)
        {
            if (item.Value <= q)
            { 
                Console.WriteLine($"- {item.Key} | {item.Value} unidades");   
            }
        }
    }
}
