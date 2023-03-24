/* Módulo Model Perfil
* Classe Perfil
* Descrição: Classe que representa a entidade Perfil
* Autor: Jussan Igor da Silva
* Data: 15/03/2023
* Versão: 1.5
*/

using System;
using Banco;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Model
{   public enum TipoPerfil
    {
        Admin,
        User
    }
    public class Perfil
    {
        public int Id { get; set; }
        public TipoPerfil Tipo { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Perfil()
        {
        }

        public Perfil(int UsuarioId, TipoPerfil Tipo)
        {
            this.UsuarioId = UsuarioId;
            this.Tipo = Tipo;
            DataBase db = new DataBase();
            db.Perfis.Add(this);
            db.SaveChanges();

            this.Usuario = Usuario.ReadUsuario(UsuarioId);
        }


        public override string ToString()
        {
            return $"Id = {Id} / TipoPerfil = {Tipo} / Usuario = {Usuario.Nome}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
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
            Perfil perfil = (Perfil)obj;
            return Id == perfil.Id;
        }

        // ------------Métodos CRUD------------

        public static Perfil ReadPerfil(int id)
        {
            DataBase db = new DataBase();
            try
            {
                Perfil perfil = (from p in db.Perfis
                                 where p.Id == id
                                 select p).First();
                return perfil;
            } catch (Exception)
            {
                throw new Exception("Perfil não foi encontrado");
            }
        }

        public static void DeletePerfil(int Id)
        {
            DataBase db = new DataBase();
            Perfil perfil = ReadPerfil(Id);
            db.Perfis.Remove(perfil);
            db.SaveChanges();
        }

        public static List<Perfil> ListarPerfis()
        {
            DataBase db = new DataBase();
            return db.Perfis.Include("Usuario").ToList();
        }

        public static Perfil ListaPerfilPorUsuario(int UsuarioId)
        {
            DataBase db = new DataBase();
            try
            {
                Perfil perfil = (from p in db.Perfis
                                 where p.UsuarioId == UsuarioId
                                 select p).First();
                return perfil;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}