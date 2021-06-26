using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATVitor.Models;
using System.Data.SqlClient;
using System.Data;
using ATVitor.Database;
using ATVitor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ATVitor.Services {

    public class AmigosService {

        private AmigosDb db;

        public AmigosService(AmigosDb db) {
            this.db = db;
        }

        public void CadastrarAmigo(string nome, string sobrenome, DateTime aniversario) {
            Amigo amigo = new Amigo();

            amigo.Nome = nome;
            amigo.Sobrenome = sobrenome;
            amigo.Aniversario = aniversario;

            db.Amigos.Add(amigo);
            db.SaveChanges();
        }

        public List<Amigo> ListarAmigos() {
            var amigos = db.Amigos.ToList();
            return amigos;
        }

        public List<Amigo> OrdenarAniversarios() {
            Amigo amigoData = new Amigo();
            var amigos = ListarAmigos();
            List<Amigo> amigosOrdenados = new List<Amigo>();
            foreach(Amigo dataAmigo in amigos) {
                
                DateTime novaData = new DateTime();
                novaData.AddDays(dataAmigo.Aniversario.Day);
                novaData.AddMonths(dataAmigo.Aniversario.Month);
                amigoData.Aniversario.AddDays(novaData.Day);
                amigoData.Aniversario.AddMonths(novaData.Month);
                amigosOrdenados.Add(amigoData);
            }
            return amigosOrdenados;
        }

        public List<Amigo> ListarAmigos(string nome) {
            List<Amigo> amigos = new List<Amigo>();
            if(nome != null) {
                amigos = BuscarPeloNome(nome);
            }
            if(nome == null) {
                amigos = db.Amigos.ToList();
            }
            return amigos;
        }

        public Amigo BuscarPelo(int identificador) {
            var amigo = db.Amigos.Find(identificador);
            return amigo;
        }

        public List<Amigo> BuscarPeloNome(string nome) {
            List<Amigo> amigosEncontrados = new List<Amigo>();
            amigosEncontrados = db.Amigos.Where(n => n.Nome == nome).ToList();
            return amigosEncontrados;
        }

        public void ExcluirAmigo(int id) {
            //AmigosDb db = new AmigosDb();
            Amigo amigo = db.Amigos.Find(id);
            db.Amigos.Remove(amigo);
            db.SaveChanges();
        }

        public void EditarAmigo(int id, string nome, string sobrenome, DateTime aniversario) {
            Amigo amigo = BuscarPelo(id);
            amigo.Nome = nome;
            amigo.Sobrenome = sobrenome;
            amigo.Aniversario = aniversario;
            db.Amigos.Update(amigo);
            db.SaveChanges();
        }
    }

}
