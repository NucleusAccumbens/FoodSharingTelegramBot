using FoodSharing.TelegramBot.Abstractions;
using FoodSharing.TelegramBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.TelegramBot
{
    public class CommandService : ICommandService
    {
        private List<ATelegramCommand> telegramCommands = new List<ATelegramCommand>();
        public List<ATelegramCommand> GetCommands()
        {
            telegramCommands.Add(new StartCommand());
            return telegramCommands;
        }
    }
}
