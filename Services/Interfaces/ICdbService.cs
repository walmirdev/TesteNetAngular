namespace TesteNetAngular.Services.Interfaces
{
    public interface ICdbService
    {
        CdbResult CalcCdb(decimal valor, int prazo);
    }
}
