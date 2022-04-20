using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FoodSharing.TelegramBot.Abstractions
{
    public interface ITelegramBot
    {
        Task<bool> SaveUserInDb(Update ubdate);
        Task<bool> CheckUserIsAdmin(long chatId);
        string StartReceiving();
    }
}
