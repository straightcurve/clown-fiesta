using System;

public interface IEntity
{
    Guid ID { get; }

    void Initialize(Guid id);
    void Destroy();
}