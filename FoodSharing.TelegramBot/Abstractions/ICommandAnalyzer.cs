using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FoodSharing.TelegramBot.Abstractions
{
    public interface ICommandAnalyzer
    {
        Task AnalyzeCommand
            (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ITelegramBot bot);
    }
}
