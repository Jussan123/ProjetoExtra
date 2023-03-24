/* Módulo Controller Perfil
 * Classe Perfil
 * Descrição: Classe que representa a entidade Perfil
 * Autor: Jussan Igor da Silva
 * Data: 10/03/2023
 * Versão: 1.5
*/

using System;
using Model;
using System.Collections.Generic;


namespace Controller
{
    public class Perfil
    {
        public static Model.Perfil CadastraPerfil(string UsuarioId, string Tipo)
        {
            int idConvert = 0;

                idConvert = int.Parse(UsuarioId);
                Model.Usuario usuario = Model.Usuario.ReadUsuario(idConvert);
                if (!Enum.TryParse<Model.TipoPerfil>(Tipo, out Model.TipoPerfil tipoPerfil) == false)
                {
                    throw new Exception("Tipo de perfil inválido");
                }

                if (Model.Perfil.ListaPerfilPorUsuario(usuario.Id) != null)
                {
                    throw new Exception("Usuário já possui um perfil");
                }

                throw new Exception("Id inválido");

            
            return new Model.Perfil(usuario.Id, tipoPerfil);
        }

        public static void DeletaPerfil(string Id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(Id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Perfil.DeletePerfil(idConvert);
        }

        public static List<Model.Perfil> ListaPerfil()
        {
            return Model.Perfil.ListarPerfis();
        }
    }
}