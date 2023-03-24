/* Módulo Controller
 * Classe Usuario
 * Descrição: Classe que representa a entidade Usuario
 * Autor: Jussan Igor da Silva
 * Data: 10/03/2023
 * Versão: 1.2
*/

using System;
using Banco;
using Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Controller
{
    public class Usuario
    {
        public static Model.Usuario CadastraUsuario(
            string Nome, 
            string Email, 
            string Senha)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w))){2,3})+)$");
            Match match = regex.Match(Email);
            if (!match.Success) {
                throw new Exception("Email inválido");
            }

            Model.Usuario usuario = new Model.Usuario(Nome, Email, Senha);
            return usuario;
        }

   
        public static Model.Usuario AlteraUsuario(
            string Id, 
            string Nome, 
            string Email, 
            string Senha)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(Id);
                return Model.Usuario.UpdateUsuario(idConvert, Nome, Email, Senha);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
        }

        public static void DeletaUsuario(string Id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(Id);
                Model.Usuario.DeleteUsuario(idConvert);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
        }

        public static List<Model.Usuario> ListaUsuario()
        {
            return Model.Usuario.ReadAllUsuario();
        }

        public static Model.Usuario ListaUsuarioPorEmail(string Email)
        {
            return Model.Usuario.ReadUsuarioEmail(Email);
        }
    }
}