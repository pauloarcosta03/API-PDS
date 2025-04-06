﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Utilizador
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public int Nif { get; set; }
        public int NPorta { get; set; }

        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        [ForeignKey("GestorCondominio")]
        public int GestorCondominioId { get; set; }
        public GestorCondominio GestorCondominio { get; set; }
    }
}
