using Domain.DTO;
using Domain.Exceptions;
using Domain.Interface.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Banco;

[Route("api/bankslip")]
[ApiController]
public class BoletoController(IBoletoApplication boletoApplication) : Controller
{
    private readonly IBoletoApplication _boletoApplication = boletoApplication;

    /// <summary>
    /// Rota para salvar informações de um boleto
    /// </summary>
    /// <param name="banco"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> SaveOne([FromBody] BoletoDto banco)
    {
        try
        {
            await _boletoApplication.Cadastrar(banco);
            return Ok();
        }
        catch (FluentValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }


    /// <summary>
    /// Rota para obter um único boleto pelo código dele
    /// </summary>
    /// <param name="codigoBoleto"></param>
    /// <returns></returns>
    [HttpGet("{codigoBoleto}"), ActionName("Get single bank")]
    [ProducesResponseType(200), ProducesResponseType(404)]
    public async Task<ActionResult> GetSingleBankSlip(int codigoBoleto)
    {
        try
        {
            var banco = await _boletoApplication.Buscar(codigoBoleto);

            return Ok(banco);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
