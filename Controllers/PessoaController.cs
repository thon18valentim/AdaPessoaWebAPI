using Microsoft.AspNetCore.Mvc;

namespace AdaPessoaWebApplication.Controllers
{
  [ApiController]
  [Route("api/person")]
  public class PessoaController : ControllerBase
  {
    private static int idContador;
    private static readonly List<Pessoa> pessoas;

    static PessoaController()
    {
      idContador = 0;
      pessoas = new();
    }

    [HttpPost]
    public IActionResult Criar(string nome, string cidade)
    {
      if (nome == default || cidade == default)
        return BadRequest("Nome e Cidade não podem ser parâmetros nulos");

      idContador++;

      var pessoa = new Pessoa(idContador, nome, cidade);

      pessoas.Add(pessoa);
      return Ok($"{pessoa.Nome} cadastrado com sucesso");
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, string nome, string cidade)
    {
      if (nome == default || cidade == default)
        return BadRequest("Nome e Cidade não podem ser parâmetros nulos");

      var pessoa_editada = pessoas.FirstOrDefault(p => p.Id == id);

      if (pessoa_editada == default)
        return StatusCode(500, $"Pessoa com id: {id}, não existe");

      pessoa_editada.Edit(nome, cidade);

      return Ok($"Pessoa com id:{id} editada com sucesso");
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
      var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

      if (pessoa == default)
        return BadRequest($"Pessoa com id: {id} não existe.");

      pessoas.Remove(pessoa);
      return Ok($"Pessoa com id:{id} deletada com sucesso.");
    }

    [HttpGet("{id}")]
    public IActionResult Listar(int id)
    {
      var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

      if (pessoa == default)
        return BadRequest($"Pessoa com id:{id} não existe.");

      return Ok(pessoa);
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
      return Ok(string.Join("\n", pessoas));
    }
  }
}