namespace ItemService.EventProcessor
{
    public interface IProcessaEvento
    {
        void ProcessarEvento(string mensagem);
    }
}
