namespace Domain.Common.Interfaces;

public interface IEntity<out T>
{
    T Id { get; }
}