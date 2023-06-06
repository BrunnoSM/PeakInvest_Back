using Microsoft.AspNetCore.Mvc;
using Peak.Api.Models;

namespace Peak.Api.Controllers;

[ApiController]
public class ClientesController : ControllerBase
{
    List<KeyValuePair<int, string>> listaDeClientes;

    public ClientesController()
    {
        listaDeClientes = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1, "João"),
            new KeyValuePair<int, string>(2, "Maria"),
            new KeyValuePair<int, string>(3, "Ana")
        };
    }

    [HttpGet]
    [Route("usuario")]
    public Usuario ObterUsuario(int id)
    {
        string nome = listaDeClientes.Find(x => x.Key == id).Value;
        Usuario usuario = new Usuario();
        usuario.Id = id;
        usuario.Nome = nome;

        return usuario;
    }

    [HttpGet]
    [Route("calcular")]
    public Emprestimo CalcularValorDoEmprestimo(int numeroDeParcelas, decimal valorDoEmprestimo)
    {
        decimal taxa = 0.05m;
        decimal valorTotal = numeroDeParcelas * valorDoEmprestimo;
        decimal valorComTaxa = valorTotal + (valorTotal * taxa);

        Emprestimo emprestimo = new Emprestimo()
        {
            ValorDoEmprestimo = valorDoEmprestimo,
            NumeroDeParcelas = numeroDeParcelas,
            ValorFinal = valorComTaxa
        };

        return emprestimo;
    }
}
