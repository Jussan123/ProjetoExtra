using System;
using Controller;

namespace View
{
    public class Sessao
    {
        public static void MenuSessao()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Criar login");
                Console.WriteLine("2 - Criar logout");
                Console.WriteLine("3 - Listar sessões");
                Console.WriteLine("0 - Voltar");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CriandoLogin();
                        break;
                    case 2:
                        CriandoLogout();
                        break;
                    case 3:
                        ListandoSessoes();
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

        public static void CriandoLogin()
        {
            Console.WriteLine("Digite o seu Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite sua Senha: ");
            string Senha = Console.ReadLine();
            try
            {
                Model.Sessao sessao = Controller.Sessao.Login(Email, Senha);
                Console.WriteLine("Login realizado com sucesso");
                Console.WriteLine(sessao);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void CriandoLogout()
        {
            Console.WriteLine("Para Encerrar sua Sessão:");
            Console.WriteLine("Digite o ID da Sessão: ");
            string Id = Console.ReadLine();
            try
            {
                Controller.Sessao.Logoff(Id);
                Console.WriteLine("Sessão encerrada com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ListandoSessoes()
        {
            Console.WriteLine("Está é a lista de Sessões, atualmente: ");
            try
            {
                List<Model.Sessao> sessoes = Controller.Sessao.ListaSessao();
                foreach(Model.Sessao sessao in sessoes)
                {
                    Console.WriteLine(sessao);
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}