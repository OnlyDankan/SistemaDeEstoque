using System;
using Desafios.Models;
using Desafios.Services;
using System.Collections.Generic;
using System.Linq;


namespace Desafios
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProdutoService produtoService = new ProdutoService(); //aqui eu peço pra ele fazer a função já definida em ProdutoService

            bool executando = true;

            while (executando)
            {
                Console.Clear();

            Console.WriteLine("Sistema de Estoque");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Buscar Produto");
            Console.WriteLine("4 - Entrada de estoque");
            Console.WriteLine("5 - Saída de estoque");
            Console.WriteLine("6 - Relatórios");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            int menuOpcao = int.Parse(Console.ReadLine() ?? "");

            

            Console.Clear();

            switch (menuOpcao)
            {
                case 1:
                    produtoService.CadastrarProduto(); //Aqui ele faz a função dele caso o user escolha cadastro.
                break;

                case 2:
                  produtoService.ListarProdutos();
                  
                break;

                case 3:
                    produtoService.BuscarProdutos(); 
                break;

                case 4:
                    produtoService.EntradaProduto();
                break;

                case 5:
                    produtoService.SaidaProduto();
                break;
                
                case 0:
                    executando = false;
                    Console.WriteLine("Encerrando o sistema...");
                break;

                default:
                    Console.WriteLine("Opção inválida.");
                break; 
            }

            if (executando)
                {
                    Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
          }
        }
      }
    }