﻿using System.Collections;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form, ITelaBase<Questao>
    {
        private Questao _questao;

        private bool isValid;

        private List<Materia> ListaMateria { get; set; }

        public TelaQuestaoForm()
        {
            InitializeComponent();
        }

        public Questao? Entidade
        {
            set
            {
                txtId.Text = value.Id.ToString();
                txtDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                txtMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                txtEnunciado.Text = value.Enunciado;
                listAlternativas.Items.AddRange(value.Alternativas.ToArray());
                _questao = value;
            }
            get
            {
                return _questao;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            Disciplina? disciplina = txtDisciplina.SelectedItem as Disciplina;

            Materia? materia = txtMateria.SelectedItem as Materia;

            List<string> alternativas = listAlternativas.Items.Cast<string>().ToList();

            _questao = new Questao(materia, txtEnunciado.Text, alternativas, listAlternativas.CheckedItems[0].ToString());

            if (_questao.Id == 0)
                _questao.Id = int.Parse(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtMateria.TextChanged += ValidarCampos;
            txtDisciplina.TextChanged += ValidarCampos;
            txtEnunciado.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Questao questao = new();

            lbErroAlternativas.Visible = false;

            if (questao.ValidarQtdAlternativas(listAlternativas.Items.Count))
            {
                lbErroAlternativas.Text = "*Apenas 3 a 4 alternativas";
                lbErroAlternativas.Visible = true;
            }
            else if (questao.ValidarAlternativaCorreta(listAlternativas.CheckedItems.Count))
            {
                lbErroAlternativas.Text = "*Precisa ter 1 Resposta Correta";
                lbErroAlternativas.Visible = true;
            }

            lbErroEnunciado.Visible = questao.ValidarCampoVazio(txtEnunciado.Text);

            //lbErroMateria.Visible = questao.ValidarCampoVazio(txtDisciplina.Text);
            //lbErroDisciplina.Visible = questao.ValidarCampoVazio(txtDisciplina.Text);

            if (lbErroDisciplina.Visible || lbErroMateria.Visible || lbErroEnunciado.Visible || lbErroAlternativas.Visible)
                isValid = false;
            else
                isValid = true;
        }

        private void btnAddAlternativa_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            Questao questao = new();

            if (!string.IsNullOrEmpty(txtResposta.Text))
            {
                if (questao.ValidarAlternativaExistente(txtResposta.Text, listAlternativas.Items.Cast<string>().ToList()))
                {
                    lbErroAlternativas.Text = "*Alternativa já existente";
                    lbErroAlternativas.Visible = true;
                }
                else
                {
                    listAlternativas.Items.Add(txtResposta.Text);
                    lbErroAlternativas.Visible = false;
                }
            }
        }

        private void btnExcluirAlternativa_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (listAlternativas.SelectedIndex != -1)
                listAlternativas.Items.RemoveAt(listAlternativas.SelectedIndex);
        }

        private void listAlternativas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (int index in listAlternativas.CheckedIndices)
            {
                if (index != e.Index)
                    listAlternativas.SetItemChecked(index, false);
            }
        }
    }
}
