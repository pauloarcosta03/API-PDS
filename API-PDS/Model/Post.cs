﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tag { get; set; }
        public bool Aceite { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("GestorCondominio")]
        public int GestorCondominioId { get; set; }
        public GestorCondominio GestorCondominio { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Participante> Participantes { get; set; }
        public ICollection<Notificacao> Notificacoes { get; set; }
    }
}
