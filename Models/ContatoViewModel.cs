using System;

namespace BrunoTeste.Models;

public class ContatoViewModel
{
    public int Id { get; set; }
    public int IdPessoa { get; set; }
    public string? Nome { get; set; }
    public string? Tipo { get; set; }
    public string? Contato { get; set; }
}
