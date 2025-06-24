namespace MarketWeight.Core.Persistencia;

public interface IRepoAltaAsync<T>
{
    Task AltaAsync(T elemento);
}