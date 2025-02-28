using MDR.Core.DomainObjects;

namespace MDR.CadastroDomain.Entities;

public class Departamento : Entity
{
    public string Nome { get; private set; }
    public ICollection<Pessoa> Pessoas { get; private set; }

    public Departamento()
    { }

    public Departamento(string nome) => Nome = nome;

    public void Validar()
    {
        DomainValidation.ValidarSeVazioNulo(Nome, "O Nome deve ser preenchido");
        DomainValidation.ValidarCaracteres(Nome, 60, "O Nome deve ter no maximo 120 caracteres");
    }
}
