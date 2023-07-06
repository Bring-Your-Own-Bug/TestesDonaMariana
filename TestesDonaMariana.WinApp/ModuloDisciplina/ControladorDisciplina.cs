using Microsoft.Identity.Client;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private readonly TabelaDisciplinaControl _tabelaDisciplina;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioMateria _repositorioMateria;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _tabelaDisciplina = _tabela;
            _repositorioDisciplina = _repositorio;
            _repositorioMateria = _repositorio2;
        }

        public ControladorDisciplina()
        {
            
        }

        public override void Excluir()
        {
            Disciplina? disciplina = _tabela.ObterRegistroSelecionado();
            TelaPrincipalForm.AtualizarStatus($"Excluindo {typeof(Disciplina).Name}");

            if (disciplina.ValidarDependencia(disciplina, _repositorioMateria.ObterListaRegistros()))
            {
                MessageBox.Show($"Existem Matérias cadastradas na Disciplina \"{disciplina.Nome}\", Exclua-as para excluir essa Disciplina",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                if (MessageBox.Show($"Deseja mesmo excluir?", $"Exclusão de {typeof(Disciplina).Name}",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _repositorio.Excluir(disciplina);

            CarregarRegistros();
        }

        public List<Disciplina> ObterListaDisciplina()
        {
            return new RepositorioDisciplina().ObterListaRegistros();
        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            return _tabelaDisciplina;
        }
    }
}
