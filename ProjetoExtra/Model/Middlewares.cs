using System;
using System.Collections.Generic;

namespace Model
{
    public class Middleware
    {
        public static void VerificarSeUsuarioEstaLogado()
        {
            // Verificar se usuário está logado
            // Se não estiver logado, redirecionar para tela de login
            // Se estiver logado, permitir acesso
            
        }

        public static void VerificarSeUsuarioEhAdmin()
        {
            // Verificar se usuário é admin
            // Se não for admin, redirecionar para tela de login
            // Se for admin, permitir acesso
        }

        public static void VerificarSeUsuarioEhUser()
        {
            // Verificar se usuário é user
            // Se não for user, redirecionar para tela de login
            // Se for user, permitir acesso
        }
    }
}