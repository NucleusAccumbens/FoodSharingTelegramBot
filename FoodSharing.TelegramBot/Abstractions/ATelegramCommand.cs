using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FoodSharing.TelegramBot.Abstractions
{
    public abstract class ATelegramCommand
    {
        public abstract string Name { get; }
        public abstract Task Execute(Update update, ITelegramBotClient client, CancellationToken cancellationToken);
        public virtual bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}
