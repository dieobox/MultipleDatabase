#region Using

using System.Threading.Tasks;

#endregion

namespace QuickMonServer.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}