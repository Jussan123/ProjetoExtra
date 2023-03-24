/* Módulo View
 * Classe Usuario
 * Descrição: Classe que representa a entidade Usuario
 * Autor: Jussan Igor da Silva
 * Data: 10/03/2023
 * Versão: 1.2
*/

using System;
using Controller;

namespace View
{
    public class Usuario
    {

        public static void MenuUsuario()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Listar usuários");
                Console.WriteLine("3 - Buscar usuário por ID");
                Console.WriteLine("4 - Atualizar usuário");
                Console.WriteLine("5 - Deletar usuário");
                Console.WriteLine("0 - Voltar");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrandoUsuario();
                        break;
                    case 2:
                        ListandoUsuarios();
                        break;
                    case 3:
                        BuscandoUsuarioPorId();
                        break;
                    case 4:
                        AtualizandoUsuario();
                        break;
                    case 5:
                        DeletandoUsuario();
                        break;
                    case 0:
                        Console.WriteLine("Voltando ao menu principal");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);
        }


//  ------------------- Métodos -------------------
        public static void CadastrandoUsuario()
        {
            Console.WriteLine("Digite seu nome: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Confirme sua senha: ");
            string ConfirmarSenha = Console.ReadLine();
            if (Senha != ConfirmarSenha)
            {
                Console.WriteLine("Senhas não conferem");
                return;
            }
            Controller.Usuario.CadastraUsuario(Nome, Email, Senha);
        }

        public static void ListandoUsuarios()
        {
            foreach(Model.Usuario usuario in Controller.Usuario.ListaUsuario()) {
                Console.WriteLine(usuario);
            }
        }

        public static void AtualizandoUsuario()
        {
            Console.WriteLine("Atualizando usuário");
            Console.WriteLine("Digite o Id do usuário que deseja atualizar: ");
            string  Id = Console.ReadLine();
            Console.WriteLine("Digite o novo nome: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o novo email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite a nova senha: ");
            string Senha = Console.ReadLine();
            Controller.Usuario.AlteraUsuario(Nome, Email, Senha, Id);
        }

        public static void DeletandoUsuario()
        {
            Console.WriteLine("Deletando usuário");
            Console.WriteLine("Digite o Id do usuário que deseja deletar: ");
            string Id = Console.ReadLine();
            Controller.Usuario.DeletaUsuario(Id);
        }

        public static void BuscandoUsuarioPorId()
        {
            Console.WriteLine("Buscando usuário por Id");
            Console.WriteLine("Digite o Email do usuário que deseja buscar: ");
            string Email = Console.ReadLine();
            Controller.Usuario.ListaUsuarioPorEmail(Email);
        }
    }
}