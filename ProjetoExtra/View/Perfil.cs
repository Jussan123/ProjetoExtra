/* 
    Classe: Perfil
    Descrição: Classe responsável por exibir o perfil do usuário
    Autor: Jussan Igor da Silva
    Data: 15/03/2023
    Versão: 1.5
*/

using System;
using Controller;

namespace View
{
    public class Perfil
    {
        public static void MenuPerfil()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Cadastrar perfil");
                Console.WriteLine("2 - Listar perfis");
                Console.WriteLine("3 - Deletar perfil");
                Console.WriteLine("0 - Voltar");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrandoPerfil();
                        break;
                    case 2:
                        ListandoPerfis();
                        break;
                    case 3:
                        DeletandoPerfil();
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

        public static void CadastrandoPerfil()
        {
            Console.WriteLine("Cadastrando o perfil do usuário");
            Console.WriteLine("Digite o Id do usuário: ");
            string UsuarioId = Console.ReadLine();
            Console.WriteLine("Digite o Tipo do perfil:");
            string tipo = Console.ReadLine();
            try
            {
                Model.Perfil perfil = Controller.Perfil.CadastraPerfil(UsuarioId, tipo);
                Console.WriteLine("Perfil cadastrado com sucesso");
                Console.WriteLine(perfil);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ListandoPerfis()
        {
            Console.WriteLine("Listando os perfis");
            try
            {
                List<Model.Perfil> perfis = Controller.Perfil.ListaPerfil();
                foreach (Model.Perfil perfil in perfis)
                {
                    Console.WriteLine(perfil);
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeletandoPerfil()
        {
            Console.WriteLine("Deletando o perfil do usuário");
            Console.WriteLine("Digite o Id do perfil: ");
            string id = Console.ReadLine();
            try
            {
                Controller.Perfil.DeletaPerfil(id);
                Console.WriteLine("Perfil deletado com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}