using System;

namespace kanbanboard.contracts
{
    public interface IPubSubProvider
    {
        void Subscribe(Action onChange);
        
        void Publish();
    }
}