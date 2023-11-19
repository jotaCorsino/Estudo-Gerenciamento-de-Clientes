using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Program;

namespace Exercicio01.Entities
{
    internal class Cadastro : Validador
    {
        static List<Cliente> Clientes = new List<Cliente>();
        public static int novoId = ObterNumerosDeClientes() + 1;

        public static int ObterNumerosDeClientes()
        {
            return Clientes.Count;
        }

        private static int GerarNovoId()
        {
            return novoId++;
        }

        public static void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            Console.Clear();
            Console.WriteLine("Insira os dados do cliente:");
            Console.WriteLine();

            string nome = "";

            bool validarNome = true;
            while (validarNome)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                if (!Validador.NomeEhValido(nome))
                {
                    Console.WriteLine("Nome inválido, por favor, verifique e tente novamente!");
                }
                else
                {
                    cliente.Nome = nome;
                    validarNome = false;
                }
            }

            string email = "";

            bool validarEmail = true;
            while (validarEmail)
            {
                Console.Write("E-mail: ");
                email = Console.ReadLine();

                if (!Validador.EmailEhValido(email))
                {
                    Console.WriteLine("E-mail inválido, por favor, verifique e tente novamente!");
                }
                else
                {
                    cliente.Email = email;
                    validarEmail = false;
                }
            }

            string telefone = "";

            bool validarTelefone = true;
            while (validarTelefone)
            {
                Console.Write("Telefone: ");
                telefone = Console.ReadLine();

                if (!Validador.TelefoneEhValido(telefone))
                {
                    Console.WriteLine("Telefone inválido, por favor, verifique e tente novamente!");
                }
                else
                {
                    cliente.Telefone = telefone;
                    validarTelefone = false;
                }
            }

            cliente.Id = GerarNovoId();
            Clientes.Add(cliente);

            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.WriteLine(cliente.ToString());
        }

        public static void RemoverCliente(Cliente cliente)
        {
            Console.WriteLine();
            Console.WriteLine($"Tem certeza que deseja apagar os dados de {cliente.Nome}?");
            Console.WriteLine("Uma vez apagados, não será possível recupera-los pois os dados serão apagados permanentemente do sistema.");

            bool confirmacaoRemover = true;
            while (confirmacaoRemover)
            {
                Console.WriteLine();
                Console.WriteLine("Digite REMOVER CLIENTE para remove-lo do sistema:");
                string removerCLiente = Console.ReadLine();

                if (removerCLiente == "REMOVER CLIENTE".ToUpper())
                {
                    Clientes.Remove(cliente);
                    Console.WriteLine("Os dados do cliente foram apagados com sucesso!");
                    confirmacaoRemover = false;
                    return;
                }
                else
                {
                    Console.WriteLine("Confirmação inválida!");
                    break;
                }
            }
        }

        public static void BuscarCliente()
        {
            bool exibirMenuBuscadorDeCliente = true;
            while (exibirMenuBuscadorDeCliente)
            {
                Console.Clear();
                Console.WriteLine("Buscador de cliente:");
                Console.WriteLine("1 - Buscar Cliente pelo Id");
                Console.WriteLine("2 - Buscar Cliente pelo Nome");
                Console.WriteLine("3 - Voltar ao menu");
                Console.Write("Digite a sua opção: ");

                string opcaoMenuBuscador = Console.ReadLine();

                switch (opcaoMenuBuscador)
                {
                    case "1":
                        BuscarClienteId();
                        return;

                    case "2":
                        BuscarClienteNome();
                        return;

                    case "3":
                        exibirMenuBuscadorDeCliente = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        public static void BuscarClienteId()
        {
            Console.Clear();
            Console.WriteLine("Digite o numero ID do cliente:");

            if (int.TryParse(Console.ReadLine(), out int inputId))
            {
                Console.Clear();
                Console.WriteLine("Digite o id cliente:");

                for (int i = 0; i < Clientes.Count; i++)
                {
                    if (Clientes[i].Id == inputId)
                    {
                        Console.WriteLine(Clientes[i].ToString());
                        MenuControleCliente(Clientes[i]);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{inputId} não encontrado na lista de clientes.");
            }
        }

        public static void BuscarClienteNome()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome cliente:");
            string inputNome = Console.ReadLine();

            for (int i = 0; i < Clientes.Count; i++)
            {
                if (Clientes[i].Nome == inputNome)
                {
                    Console.WriteLine(Clientes[i].ToString());
                    MenuControleCliente(Clientes[i]);
                    return;
                }
            }
            Console.WriteLine($"{inputNome} não encontrado na lista de clientes.");

        }

        public static void MenuControleCliente(Cliente cliente)
        {
            bool exibirMenuBuscadorDeCliente = true;
            while (exibirMenuBuscadorDeCliente)
            {
                Console.WriteLine();
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Editar Cliente");
                Console.WriteLine("2 - Remover Cliente");
                Console.WriteLine("3 - Voltar ao menu");
                Console.Write("Digite a sua opção: ");
                string opcaoMenuCliente = Console.ReadLine();

                switch (opcaoMenuCliente)
                {
                    case "1":
                        EditarCliente(cliente);
                        return;

                    case "2":
                        RemoverCliente(cliente);
                        return;

                    case "3":
                        exibirMenuBuscadorDeCliente = false;
                        return;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        public static void ListarClientes()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de clientes:");

            if (Clientes != null && Clientes.Count > 0)
            {
                for (int i = 0; i < Clientes.Count; i++)
                {
                    Console.WriteLine($"ID: {Clientes[i].Id} - {Clientes[i].Nome}, E-mail: {Clientes[i].Email}, Telefone: {Clientes[i].Telefone}");
                }
            }
            else
            {
                Console.WriteLine("A lista de clientes está vazia.");
            }
        }

        public static void EditarCliente(Cliente cliente)
        {
            bool exibirMenuEditar = true;
            while (exibirMenuEditar)
            {
                Console.Clear();
                Console.WriteLine("[Alterando cadastro do cliente]");

                string novoNome = "";

                bool validarnovoNome = true;
                while (validarnovoNome)
                {
                    Console.Write("[Editar] Nome: ");
                    novoNome = Console.ReadLine();

                    if (!Validador.NomeEhValido(novoNome))
                    {
                        Console.WriteLine("Nome inválido, por favor, verifique e tente novamente!");
                    }
                    else
                    {
                        cliente.Nome = novoNome;
                        validarnovoNome = false;
                    }
                }

                string novoEmail = "";

                bool validarEmail = true;
                while (validarEmail)
                {
                    Console.Write("[Editar] E-mail: ");
                    novoEmail = Console.ReadLine();

                    if (!Validador.EmailEhValido(novoEmail))
                    {
                        Console.WriteLine("E-mail inválido, por favor, verifique e tente novamente!");
                    }
                    else
                    {
                        cliente.Email = novoEmail;
                        validarEmail = false;
                    }
                }

                string novoTelefone = "";

                bool validarTelefone = true;
                while (validarTelefone)
                {
                    Console.Write("[Editar] Telefone: ");
                    novoTelefone = Console.ReadLine();

                    if (!Validador.TelefoneEhValido(novoTelefone))
                    {
                        Console.WriteLine("Telefone inválido, por favor, verifique e tente novamente!");
                    }
                    else
                    {
                        cliente.Telefone = novoTelefone;
                        validarTelefone = false;
                    }
                }

                Console.WriteLine($"Cliente {cliente.Nome} editado com sucesso.");
                Console.WriteLine();
                Console.WriteLine(cliente.ToString());
                exibirMenuEditar = false;
            }
        }
    }
}
