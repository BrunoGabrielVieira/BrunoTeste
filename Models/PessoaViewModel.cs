namespace BrunoTeste.Models;

public class PessoaViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public string? Rg { get; set; }
    public List<EnderecoViewModel> Enderecos { get; set; }
    public List<ContatoViewModel> Contatos { get; set; }
}
