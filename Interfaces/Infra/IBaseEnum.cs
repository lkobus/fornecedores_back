namespace Interfaces.Infra
{
    public interface IBaseEnum<T> 
    {

        int Codigo { get; }
        T Valor { get; }

    }
}