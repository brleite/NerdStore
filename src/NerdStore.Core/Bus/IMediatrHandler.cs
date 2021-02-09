using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}