using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Desafios.Models;
using System.Linq;


namespace Desafios.Services {
    public class ProdutoService
    {
     private List<Produto> produtos = new List<Produto>();

         
    public void CadastrarProduto()
    {
        
        while (true) {

         try {
        Console.WriteLine("Cadastro de Produto");
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";


        if (string.IsNullOrWhiteSpace(nome))
             {
                throw new ArgumentException("O campo não pode ser vazio. Tente novamente.");
             } 


        Console.Write("Código: ");
        int codigo = int.Parse(Console.ReadLine() ?? "");


        if (int.IsNegative(codigo))
            {
                throw new ArgumentException("Número não válido");        
            }


        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine() ?? "");


        if (double.IsNegative(preco))
            {
                throw new Exception("Número inválido.");
            }


        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine() ?? "");


        if (int.IsNegative(quantidade))
            {
                throw new ArgumentException("Número inválido.");
            }


        Console.Write("Categoria: ");
        string categoria = Console.ReadLine() ?? "";


        if (string.IsNullOrWhiteSpace(categoria))
            {
                throw new ArgumentException ("Campo não pode ser vazio. Tente novamente");
            } 

        

        Produto produto = new Produto();
        
        produto.Nome = nome;
        produto.Codigo = codigo;
        produto.Preco = preco;
        produto.Quantidade = quantidade;
        produto.Categoria = categoria;

        produtos.Add(produto);

        Console.WriteLine("Produto Cadastrado.");
        break;
        }
         catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
      }
    }

        public void ListarProdutos()
        {
            Console.WriteLine("PRODUTOS CADASTRADOS");

            foreach (Produto produto in produtos)
            {
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Codigo: {produto.Codigo}");
                Console.WriteLine($"Preço: R$: {produto.Preco}");
                Console.WriteLine($"Quantidade: {produto.Quantidade}");
                Console.WriteLine($"Categoria: {produto.Categoria}");

                Console.WriteLine();
            
            }
        }

        public void BuscarProdutos()
        {
            Console.WriteLine("BUSCAR PRODUTO");


            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine() ?? "");

            Produto? produtoEncontrado = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if (produtoEncontrado == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine("\n=== PRODUTO ENCONTRADO ===");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Código: {produtoEncontrado.Codigo}");
            Console.WriteLine($"Preço: R$: {produtoEncontrado.Preco}");
            Console.WriteLine($"Quantidade: {produtoEncontrado.Quantidade}");
            Console.WriteLine($"Categoria: {produtoEncontrado.Categoria}");

            Console.WriteLine("\n1 - Atualizar produto.");
            Console.WriteLine("2 - Excluir produto.");
            

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AtualizarProduto(produtoEncontrado);
                    break;

                    case 2:
                        Console.WriteLine("Tem certeza que deseja remover?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não");
                        int confirmar = int.Parse(Console.ReadLine() ?? "");

                        if (confirmar == 1)
                        {
                            produtos.Remove(produtoEncontrado);

                            Console.WriteLine("Produto removido!");
                        }
                    break;
                }
            }
        }

            public void AtualizarProduto(Produto produto)
        {
            Console.Clear();


            Console.WriteLine("O que deseja alterar?");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Código");
            Console.WriteLine("3 - Preço");;
            Console.WriteLine("4 - Quantidade");
            Console.WriteLine("5 - Categoria");

            int opcao = int.Parse(Console.ReadLine() ?? "");

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Novo nome: ");
                    produto.Nome = Console.ReadLine() ?? "";
                break;
                
                case 2:
                    Console.WriteLine("Novo código: ");
                    produto.Codigo = int.Parse(Console.ReadLine() ?? "");
                break;

                case 3:
                    Console.Write("Novo preço: ");
                    produto.Preco = double.Parse(Console.ReadLine() ?? "");
                break;

                case 4:
                    Console.WriteLine("Nova quantidade: ");
                    produto.Quantidade = int.Parse(Console.ReadLine() ?? "");
                break;

                case 5:
                    Console.WriteLine("Nova categoria: ");
                    produto.Categoria = Console.ReadLine() ?? "";
                break;
            }

            Console.WriteLine("Produto atualizado com sucesso!");
        }


            /*public void RemoverProduto (Produto produto)
        {
            Console.Clear();

            Console.WriteLine("Você deseja excluir esse produto? (S/N)");
            string resposta = Console.ReadLine() ?? "";
            
            if (resposta?.ToUpper() == "S")
            {
                
                produtos.Remove(produtoEncontrado); 

                Console.WriteLine($"{produto.Nome} foi removido do estoque.");

                
            } else
            {
                return;
            }
        }*/

        public void EntradaProduto ()
        {
            Console.Clear();

            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine() ?? "");

            Produto? produtoEncontrado = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if (produtoEncontrado == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Quantidade atual: {produtoEncontrado.Quantidade}");

            Console.WriteLine("\nQuantas unidades entraram?");
            int unidades = int.Parse(Console.ReadLine() ?? "");

            
            produtoEncontrado.Quantidade += unidades;
           

            Console.Clear();

            Console.WriteLine("Entrada registrada com sucesso!");
            Console.WriteLine($"Quantidade anterior: {produtoEncontrado.Quantidade}");
            Console.WriteLine($"Entraram: {unidades}");
            Console.WriteLine($"Nova quantidade: {produtoEncontrado.Quantidade}");

           
            


        }
       


        }
     }
   

