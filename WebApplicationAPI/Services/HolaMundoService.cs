namespace WebApplicationAPI.Services
{
    public interface IHolaMundoService
    {
        string GetHolaMundo();
    }

    public class HolaMundoService : IHolaMundoService
    {
        public string GetHolaMundo()
        {
            return "Hola Mundo API";
        }
    }
}
