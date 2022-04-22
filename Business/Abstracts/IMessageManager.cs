using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IMessageManager : IManager<Message>
    {
        Task SendMessageToAdmin(Message message);
        Task SendMessageFromAdmin(Message message);
    }
}
