/* Módulo Model Sessao
* Descrição : Classe responsável pelas operações de CRUD da tabela Sessao
* Autor : Jussan Igor da Silva
* Data : 15/03/2023
* Versão : 1.3
*/

using System;
using Banco;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Sessao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }

        public Sessao()
        {
        }

        public Sessao(int UsuarioId)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            this.UsuarioId = UsuarioId;
            this.Token = token;
            this.DataCriacao = DateTime.UtcNow;
            this.DataExpiracao = DateTime.UtcNow + TimeSpan.FromDays(1);

            DataBase db = new DataBase();
            db.Sessoes.Add(this);
            db.SaveChanges();

            this.Usuario = Usuario.ReadUsuario(UsuarioId);
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
            Sessao sessao = (Sessao)obj;
            return sessao.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        public override string ToString()
        {
            bool ativa = this.DataExpiracao > DateTime.UtcNow;
            return $"Id = {Id} / Usuario = {this.Usuario.Nome} / Token = {Token} / DataCriacao = {DataCriacao} / DataExpiracao = {DataExpiracao} / Ativa = {(ativa ? "Sim" : "Não")}";
        }

        //-----------------Métodos CRUD-----------------

        public static Sessao UpdateSessao(int id, DateTime dataExpiracao)
        {
            DataBase db = new DataBase();
            try
            {
                Sessao sessao = (from s in db.Sessoes
                                 where s.Id == id
                                 select s).First();
                sessao.DataExpiracao = dataExpiracao;
                db.SaveChanges();
                return sessao;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static List<Sessao> ReadAllSessao()
        {
            DataBase db = new DataBase();
            try
            {
                List<Sessao> sessoes = db.Sessoes.Include("Usuario").ToList();
                return sessoes;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}