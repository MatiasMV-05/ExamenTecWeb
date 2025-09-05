using _15_Encapsulación_CuentaBancaria.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace _15_Encapsulación_CuentaBancaria.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaBancariaController : ControllerBase
    {
        private static List<CuentaBancaria> cuentas = new()
        {
            new CuentaBancaria
            {
                NumeroCuenta = 1234,
                nombre = "Juan Perez",  
              
            },
            new CuentaBancaria
            {
                NumeroCuenta = 5678,
                nombre = "Maria Gomez",  
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<CuentaBancaria>> GetAll()
        {
            return Ok(cuentas);
        }

        [HttpGet("{numeroCuenta:int}")]
        public ActionResult<CuentaBancaria> GetByNumeroCuenta(int numeroCuenta)
        {
            var cuenta = cuentas.FirstOrDefault(x => x.NumeroCuenta == numeroCuenta);
            if (cuenta is not null)
                return Ok(cuenta);
            else
                return NotFound();
        }

        [HttpPost("depositar/{NumeroCuenta}/{Monto}")]
        public ActionResult<CuentaBancaria> Depositar(int NumeroCuenta, decimal Monto) 
        {
            try
            {
                var cuenta = cuentas.FirstOrDefault(x => x.NumeroCuenta == NumeroCuenta);
                if (cuenta is null)
                    return NotFound("Cuenta no encontrada");

                cuenta.Depositar(Monto);  

                return Ok(new
                {
                    Mensaje = "Depósito realizado exitosamente",
                    NumeroCuenta = NumeroCuenta,
                    NuevoSaldo = cuenta.GetSaldo()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("retirar/{NumeroCuenta}/{Monto}")]
        public ActionResult<CuentaBancaria> Retirar(int NumeroCuenta, decimal Monto)  
        {
            try
            {
                var cuenta = cuentas.FirstOrDefault(x => x.NumeroCuenta == NumeroCuenta);
                if (cuenta is null)
                    return NotFound("Cuenta no encontrada");

                cuenta.Retirar(Monto);  

                return Ok(new
                {
                    Mensaje = "Retiro realizado exitosamente",
                    NumeroCuenta = NumeroCuenta,
                    NuevoSaldo = cuenta.GetSaldo()  
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}