using System.ComponentModel.DataAnnotations;

namespace _15_Encapsulación_CuentaBancaria.api.Models
{
    public class CuentaBancaria
    {
        [Key]
        public int NumeroCuenta { get; set; }

        [Required]
        public string nombre { get; set; }

        private decimal Saldo;

        public decimal SaldoAux
        {
            get { return Saldo; }
            private set { Saldo = value; }
        }

        public void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a depositar debe ser mayor a cero.");
            Saldo += monto;
        }

        public void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a retirar debe ser mayor a cero.");
            if (monto > Saldo)
                throw new Exception("Fondos insuficientes para realizar el retiro.");
            Saldo -= monto;
        }

        public decimal GetSaldo()
        {
            return Saldo;
        }
    }
}

