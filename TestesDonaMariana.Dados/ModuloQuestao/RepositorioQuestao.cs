﻿using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dados.ModuloQuestao
{
    public class RepositorioQuestao : RepositorioBaseSql<Questao>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override MapeadorBase<Questao> Mapear => new MapeadorQuestao();
    }
}
