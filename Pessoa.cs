namespace AdaPessoaWebApplication
{
  public class Pessoa
  {
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Cidade { get; private set; }

    public Pessoa(int id, string nome, string cidade)
    {
      Id = id;
      Nome = nome;
      Cidade = cidade;
    }

    public void Edit(string nome, string cidade)
    {
      Nome = nome;
      Cidade = cidade;
    }

    public override string ToString()
    {
      return $"({Id}) {Nome} - {Cidade}";
    }
  }
}
