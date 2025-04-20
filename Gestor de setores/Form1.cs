using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_setores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do setor é obrigatório.");
                return;
            }

            Setor setor = new Setor { Nome = txtNome.Text };
            Setor.InserirSetor(setor);
            MessageBox.Show("Setor cadastrado com sucesso!");
            AtualizarGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            Setor setor = new Setor
            {
                ID = int.Parse(txtID.Text),
                Nome = txtNome.Text
            };

            Setor.AtualizarSetor(setor);
            MessageBox.Show("Setor atualizado com sucesso!");
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecione um setor para excluir.");
                return;
            }

            int id = int.Parse(txtID.Text);
            Setor.ExcluirSetor(id);
            MessageBox.Show("Setor excluído com sucesso!");
            AtualizarGrid();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisar.Text;
            dgvSetores.DataSource = Setor.ListarSetorPorNome(nome);
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvSetores.DataSource = Setor.ListarTodosSetores();
        }
    }
}
