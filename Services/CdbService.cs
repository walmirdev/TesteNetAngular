using TesteNetAngular.Services.Interfaces;

namespace TesteNetAngular.Services
{
    public class CdbService : ICdbService
    {
        public CdbResult CalcCdb(decimal valor, int prazo)
        {
            if (!decimal.IsPositive(valor) || prazo <= 1 )
            {
                throw new Exception("O valor deve ser positivo e o prazo maior que 1 mês");
            }

            var bruto = valor;
            var tb = Convert.ToDecimal(1.08);
            var cdi = Convert.ToDecimal(0.009);
            for (int i = 0; i < prazo; i++)
            {
                bruto = bruto * (1 + (cdi * tb));
            }


            var lucro = bruto - valor;
            if (prazo <= 6)
            {
                lucro -= lucro * Convert.ToDecimal(0.225);
            }
            else if (prazo <= 12)
            {
                lucro -= lucro * Convert.ToDecimal(0.2);
            }
            else if(prazo <= 24)
            {
                lucro -= lucro * Convert.ToDecimal(0.175);
            }
            else
            {
                lucro -= lucro * Convert.ToDecimal(0.15);
            }


            var result = new CdbResult()
            {
                bruto = bruto,
                liquido = valor + lucro
            };

            return result;
        }
    }
}
