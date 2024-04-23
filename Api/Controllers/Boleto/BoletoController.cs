using Domain.DTO;
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
        catch (Exception)
        {
            return BadRequest();
        }
    }


    /// <summary>
    /// Rota para obter um único banco pelo código dele
    /// </summary>
    /// <param name="codigoBoleto"></param>
    /// <returns></returns>
    [HttpGet("{codigoBoleto}"), ActionName("Get single bank")]
    [ProducesResponseType(200), ProducesResponseType(404)]
    public async Task<ActionResult> GetSingleBank(int codigoBoleto)
    {
        var banco = await _boletoApplication.Buscar(codigoBoleto);

        return Ok(banco);
    }
}
