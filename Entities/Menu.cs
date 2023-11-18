using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Entities
{
    internal class Menu : Cadastro
    {
        public bool MenuStatus { get; set; }

        List<Cliente> Clientes = new List<Cliente>();
        public void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Buscar cliente");
            Console.WriteLine("3 - listar clientes");
            Console.WriteLine("4 - Encerrar");

            Console.Write("Digite a sua opção: ");
            string opcaoMenu = Console.ReadLine();

            switch (opcaoMenu)
            {
                case "1":
                    Cadastro.CadastrarCliente(Clientes);
                    break;

                case "2":
                    Cadastro.BuscarCliente(); // COM BUG
                    break;

                case "3":
                    Cadastro.ListarClientes(Clientes);
                    break;

                case "4":
                    MenuStatus = false;
                    return;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Console.WriteLine("Pressione [Enter] para continuar");
            Console.ReadLine();
        }
    }
}
