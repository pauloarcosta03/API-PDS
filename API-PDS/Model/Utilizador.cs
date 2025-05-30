﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Utilizador
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string? Foto { get; set; }
        public int Nif { get; set; }
        public int NPorta { get; set; }

        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        [ForeignKey("GestorCondominio")]
        public int? GestorCondominioId { get; set; }
        public GestorCondominio? GestorCondominio { get; set; }

        [ForeignKey("Login")]
        public int? LoginId { get; set; }
        public Login? Login { get; set; }

        public ICollection<Contacto>? Contactos { get; set; }
        public ICollection<Reuniao>? Reunioes { get; set; }
        public ICollection<Incidencia>? Incidencias { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Participante>? Participantes { get; set; }
        public ICollection<Notificacao>? Notificacoes { get; set; }

        public Utilizador()
        {
            
        }
        public Utilizador(string Nome, int Nif, int NPorta, int CondominioId, int? LoginId)
        {
            this.Nome = Nome;
            this.Nif = Nif;
            this.NPorta = NPorta;
            this.CondominioId = CondominioId;
            this.LoginId = LoginId;
        }

    }
}
