/*
------------------Sistema de controle de acesso------------------
-Criar Perfil: CRUD de perfis
    --Criar perfil para usuário - validar se o usuário já tem perfil
    --Alterar perfil
    --Excluir perfil
-Criar Sessão: CRUD de sessões
    --Criar login - Autenticação de Usuário
    --Criar Logout: Remover sessão
    --Listar Sessões
        --imprimir usuário está logado
        --imprimir se usuário é admin ou user
-Criar Middleware: Verificar se usuário está logado
-Criar Middleware: Verificar se usuário é admin
-Criar Middleware: Verificar se usuário é user

==================TABELAS==================
USUÁRIO
    ID int
    NOME String
    EMAIL String
    SENHA String

PERFIL
    ID int
    USUARIO_ID int
    perfil(admin, user) String ou Enum

SESSÃO
    ID int
    USUARIO_ID int
    TOKEN String
    DATA_CRIACAO DateTime
    DATA_EXPIRACAO DateTime

*/

using System;
using View;

namespace MenuPrincipal
{
    public class Program {
        static void Main(string[] args) {
            Console.WriteLine("Sistema de Gerenciamento de Usuários");
            Console.WriteLine("===================================");
            Console.WriteLine("1 - Menu de Usuário");
            Console.WriteLine("2 - Menu de Perfil");
            Console.WriteLine("3 - Menu de Sessão");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("===================================");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    Usuario.MenuUsuario();
                    break;
                case 2:
                    Perfil.MenuPerfil();
                    break;
                case 3:
                    Sessao.MenuSessao();
                    break;
                case 4:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}


