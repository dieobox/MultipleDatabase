﻿#region Using

using System.Threading.Tasks;

#endregion

namespace QuickMonServer.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}