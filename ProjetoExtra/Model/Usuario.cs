/* Módulo: Model
 * Classe: Usuario
 * Descrição: Classe que representa a entidade Usuario
 * Autor: Jussan Igor da Silva
 * Data: 05/03/2023 
 * Versão: 1.2
 */
using System;
using Banco;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace Model
{
    public class Usuario
    {
        public int Id { get; set; } // private int Id { get; set; } com os métodos get e set
        public string Nome { get; set; }   // private string Nome { get; set; } com os métodos get e set
        public string Email { get; set; } // private string Email { get; set; } com os métodos get e set
        public string Senha { get; set; } // private string Senha { get; set; } com os métodos get e set

        // ------------Construtores------------
        public Usuario() // public Usuario() Construtor padrão
        {
        }

        public Usuario(int Id, string Nome, string Email, string Senha) // public Usuario Construtor com parâmetros sem ID
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;

            DataBase db = new DataBase();
            db.Users.Add(this);
            db.SaveChanges();
        }
        
        public Usuario(string Nome, string Email, string Senha) // public Usuario Construtor com parâmetros sem ID
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;

            DataBase db = new DataBase();
            db.Users.Add(this);
            db.SaveChanges();
        }

        public override string ToString() // ToString() Método que retorna uma string com os dados do objeto
        {
            return $"Id: {Id} / Nome: {Nome} / Email: {Email} / Senha: {GetHashCode()}";
        }

        public override int GetHashCode() // GetHashCode() Método que retorna o HashCode do objeto
        {
            return HashCode.Combine(Senha);
        }

        public override bool Equals(object obj) // Equals(object obj) Método que compara se dois objetos tem o mesmo ID
        {
            if (obj == null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Usuario usuario = (Usuario)obj;
            return this.Id == usuario.Id;
        }
        // ------------Métodos CRUD------------

        public static Usuario UpdateUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha) //AlterarUsuario(Usuario usuario) Método que altera um usuário
        {
            try 
            {
                Usuario usuario = ReadUsuario(Id);
                usuario.Nome = Nome;
                usuario.Email = Email;
                usuario.Senha = Senha;
                DataBase db = new DataBase();
                db.Users.Update(usuario);
                db.SaveChanges();

                return usuario;
            } catch (Exception)
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public static void DeleteUsuario(int Id) //DeletarUsuario(Usuario usuario) Método que deleta um usuário
        {
            try
            { 
                Model.Usuario usuario = ReadUsuario(Id);
                DataBase db = new DataBase();
                db.Users.Remove(usuario);
                db.SaveChanges();
            } catch (Exception)
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public static Usuario ReadUsuario(int Id) //LerUsuario(int Id) Método que lê um usuário
        {
            DataBase db = new DataBase();
            try
            {
                Model.Usuario usuario = (from u in db.Users
                                         where u.Id == Id
                                         select u).First();
                return usuario;
            } catch (Exception)
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public static List<Model.Usuario> ReadAllUsuario() //LerTodosUsuario() Método que lê todos os usuários
        {
            DataBase db = new DataBase();
            List<Model.Usuario> usuarios = (from u in db.Users
                                            select u).ToList();
            return usuarios;
        }

        public static Model.Usuario ReadUsuarioId(int Id) //LerUsuarioId(int Id) Método que lê um usuário pelo ID
        {
            using (var db = new DataBase())
            {
                return db.Users.Find(Id);
            }
        }

        public static Model.Usuario ReadUsuarioEmail(string Email) //LerUsuarioEmail(string Email) Método que lê um usuário pelo Email
        {
            try
            {
                DataBase db = new DataBase();
                Model.Usuario usuario = (from u in db.Users
                                         where u.Email == Email
                                         select u).First();
                return usuario;
            } catch (Exception)
            {
                throw new Exception("Usuário não encontrado");
            }
        }
    }
}