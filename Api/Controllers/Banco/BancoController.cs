using Domain.DTO;
using Domain.Exceptions;
using Domain.Interface.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Banco;

[Route("api/bank")]
[ApiController]
public class BancoController(IBancoApplication bancoApplication) : Controller
{
    private readonly IBancoApplication _bancoApplication = bancoApplication;

    /// <summary>
    /// Rota para salvar informações de um banco
    /// </summary>
    /// <param name="banco"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> SaveOne([FromBody] BancoDto banco)
    {
        try
        {
            await _bancoApplication.Cadastrar(banco);
            return Ok();
        }
        catch(FluentValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Rota para obter todos os banco
    /// </summary>
    /// <returns></returns>
    [HttpGet, ActionName("Get all banks")]
    public async Task<ActionResult> GetAllBanks()
    {
        try
        {
            var lista = await _bancoApplication.ListarTodos();

            return Ok(lista);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Rota para obter um único banco pelo código dele
    /// </summary>
    /// <param name="codigoBanco"></param>
    /// <returns></returns>
    [HttpGet("{codigoBanco}"), ActionName("Get single bank")]
    public async Task<ActionResult> GetSingleBank(int codigoBanco)
    {
        try
        {
            var banco = await _bancoApplication.Buscar(codigoBanco);

            return Ok(banco);
        }
        catch (Exception) 
        {
            return StatusCode(500);
        }
    }
}
