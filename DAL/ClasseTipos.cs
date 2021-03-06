﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProcurarLivro
    {
        public String Titulo { get; set; }
    }

    public class Autor
    {
        public int IDAutor { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public bool PremioNobel { get; set; }
        public string ResumoObra { get; set; }
    }

    public class AutorLivro
    {
        public int IDAutorLivro { get; set; }
        public string Autor { get; set; }
        public string Livro { get; set; }
    }

    public class Livro
    {
        public int IDLivro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Categoria { get; set; }
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeStock { get; set; }
    }

    public class Categoria
    {
        public int IDCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
    }
}
