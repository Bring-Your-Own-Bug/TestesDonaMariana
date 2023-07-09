using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDuplicarTesteForm : Form
    {
        private Teste _teste;

        private bool isValid;

        private List<Teste> ListaTeste { get; set; }

        public TelaDuplicarTesteForm()
        {
            InitializeComponent();

            ListaTeste = new ControladorTeste().ObterListaTeste();
        }


        public Teste? Entidade
        {
            get => _teste;

            set
            {
                txtTitulo.Text = value.Titulo;
                cmbDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                cmbMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                numericQtdQuestoes.Value = value.NumeroDeQuestoes;

                if (value.Recuperacao == Recuperacao.Sim)
                    ckbRecuperacao.Checked = true;
                else
                    ckbRecuperacao.Checked = false;

                listQuestoesSorteadas.Items.AddRange(value.ListaQuestoes.ToArray());
                _teste = value;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            Disciplina? disciplina = cmbDisciplina.SelectedItem as Disciplina;
            Materia? materia = cmbMateria.SelectedItem as Materia;

            int quantidadeQuestoes = Convert.ToInt32(numericQtdQuestoes.Value);

            Recuperacao recuperacao = ckbRecuperacao.Checked ? Recuperacao.Sim : Recuperacao.Nao;

            List<Questao> questoes = listQuestoesSorteadas.Items.Cast<Questao>().ToList();

            _teste = new Teste(txtTitulo.Text, quantidadeQuestoes, disciplina, materia, questoes, DateTime.Now, recuperacao);

            if (_teste.Id == 0)
                _teste.Id = Convert.ToInt32(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtTitulo.TextChanged += ValidarCampos;
            cmbDisciplina.TextChanged += ValidarCampos;
            cmbMateria.TextChanged += ValidarCampos;
            numericQtdQuestoes.ValueChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Teste teste = new();

            lbErroDisciplina.Visible = false;

            if (txtTitulo.Text.ValidarCampoVazio())
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*Campo obrigatório";
            }
            else if (_teste != null && string.Equals(_teste.Titulo, txtTitulo.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (teste.ValidarNomeExistente(txtTitulo.Text, ListaTeste))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*Esse teste já existe";
            }
            else if (teste.ValidarDisciplinaExistente(cmbDisciplina.SelectedIndex))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*Esse teste já existe";
            }

            if (lbErroDisciplina.Visible)
                isValid = false;
            else
                isValid = true;
        }

        private void ckbRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                cmbMateria.SelectedItem = null;
            }
            else cmbMateria.Enabled = true;
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;

            cmbMateria.Items.AddRange(disciplina.ListaMaterias.ToArray());
        }
    }
}
