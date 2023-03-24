/* Módulo Controller Sessao
 * Classe Sessao
 * Descrição: Classe que representa a entidade Sessao
 * Autor: Jussan Igor da Silva
 * Data: 15/03/2023
 * Versão: 1.3
*/

using System;
using Model;


namespace Controller
{
    public class Sessao
    {
        public static Model.Sessao Login(string Email, string pass)
        {
            try
            {
                Model.Usuario usuario = Model.Usuario.ReadUsuarioEmail(Email);
                if (usuario.Senha != pass)
                {
                    throw new Exception("Senha incorreta");
                }
                return new Model.Sessao(usuario.Id);
            } catch (Exception e)
            {
                throw new Exception("Erro na tentiva de logar: ");
            }
        }

       
        public static void Logoff(string Id)
        {
            try
            {
                int idConvert = int.Parse(Id);
                Model.Sessao.UpdateSessao(idConvert, new DateTime());
            } catch (Exception e)
            {
                throw new Exception("Erro na tentiva de logoff: ");
            }
        }
        

        public static List<Model.Sessao> ListaSessao()
        {
            return Model.Sessao.ReadAllSessao();
        }
    }
}