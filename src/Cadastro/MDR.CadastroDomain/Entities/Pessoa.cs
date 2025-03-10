using MDR.Core.DomainObjects;
using System.Reflection.Metadata;

namespace MDR.CadastroDomain.Entities;

public class Pessoa : Entity, IAggregateRoot
{
    public Guid DepartamentoId { get; private set; }
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public int Idade { get; private set; }
    public Departamento Departamento { get; private set; }

    public Pessoa()
    { }

    public Pessoa(string nome, string sobrenome, int idade, Guid departamentoId)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Idade = idade;
        DepartamentoId = departamentoId;
    }

    #region ad-hoc
    public void AlterarNome(string nome)
    {
        DomainValidation.ValidarSeVazioNulo(nome, "O Nome deve ser preenchido");
        DomainValidation.ValidarCaracteres(nome, 60, "O Nome deve ter no maximo 120 caracteres");

        Nome = nome;
    }

    public void AlterarSobrenome(string sobrenome)
    {
        DomainValidation.ValidarSeVazioNulo(sobrenome, "O Sobrenome deve ser preenchido");
        DomainValidation.ValidarCaracteres(sobrenome, 60, "O Sobrenome deve ter no maximo 120 caracteres");

        Sobrenome = sobrenome;
    }

    public void AlterarIdade(int idade)
    {
        DomainValidation.ValidarMinimoMaximo(idade, 1, 120, "A Idade deve ser informada entre 1 e 120 anos.");
    }

    public void AlterarDepartamento(Departamento departamento)
    {
        DepartamentoId = departamento.Id;
        Departamento = departamento;
    }
    #endregion

    #region Assert Concern

    public void Validar()
    {
        DomainValidation.ValidarSeVazioNulo(Nome, "O Nome deve ser preenchido");
        DomainValidation.ValidarCaracteres(Nome, 60, "O Nome deve ter no maximo 120 caracteres");
        DomainValidation.ValidarSeVazioNulo(Sobrenome, "O Sobrenome deve ser preenchido");
        DomainValidation.ValidarCaracteres(Sobrenome, 60, "O Sobrenome deve ter no maximo 120 caracteres");
        DomainValidation.ValidarMinimoMaximo(Idade, 1, 120, "A Idade deve ser informada entre 1 e 120 anos.");
    }

    #endregion
}
