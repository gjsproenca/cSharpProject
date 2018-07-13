﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class FormCategorias : Form
    {
        DAL.CategoriaMetodos categoriaMetodos = new DAL.CategoriaMetodos();
        DAL.Categoria categoria = new DAL.Categoria();

        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
        }


        private void dataGridViewCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCategoria.Text = dataGridViewCategorias.CurrentRow.Cells[1].Value.ToString();
            textBoxDescricao.Text = dataGridViewCategorias.CurrentRow.Cells[2].Value.ToString();
        }

        public void limpar()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoria.NomeCategoria = textBoxCategoria.Text;
            categoria.Descricao = textBoxDescricao.Text;

            categoriaMetodos.Inserir(categoria);

            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();

            limpar();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoria.IDCategoria = int.Parse(dataGridViewCategorias.CurrentRow.Cells[0].Value.ToString());
            categoria.NomeCategoria = textBoxCategoria.Text;
            categoria.Descricao = textBoxDescricao.Text;

            if (MessageBox.Show("Tem a certeza que deseja alterar esta categoria?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                categoriaMetodos.Alterar(categoria);
            }

            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();

            limpar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoria.IDCategoria = int.Parse(dataGridViewCategorias.CurrentRow.Cells[0].Value.ToString());

            if (categoriaMetodos.ContarLivros(categoria) > 0)
            {
                if (MessageBox.Show("Este autor tem outros registos associados, deseja apagar o autor e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    categoriaMetodos.Eliminar(categoria);
                    categoriaMetodos.Eliminar(categoria);
                }
            }
            else
            {
                if (MessageBox.Show("Tem a certeza que deseja eliminar este autor?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    categoriaMetodos.Eliminar(categoria);
                }
            }

            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();

            limpar();
        }
    }
}
