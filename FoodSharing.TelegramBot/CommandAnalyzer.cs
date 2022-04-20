using FoodSharing.TelegramBot.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FoodSharing.TelegramBot
{
    public class CommandAnalyzer : ICommandAnalyzer
    {
        private readonly ICommandService _commandService = new CommandService();
        public async Task AnalyzeCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ITelegramBot bot)
        {
            if (update.Message != null && update.Message.Type == MessageType.Text)
            {
                await AnalizeCommandForTextMessage(botClient, update, cancellationToken, bot);
            }
        }

        private async Task AnalizeCommandForTextMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ITelegramBot bot)
        {
            var chatId = update.Message.Chat.Id;
            var message = update.Message;

            Console.WriteLine($"Получено сообщение '{message.Text}' от пользователя номер {chatId}");

            try
            {
                var res = await bot.SaveUserInDb(update);

                if (res == true)
                {
                    Console.WriteLine($"Пользователь с chatId {update.Message.Chat.Id} сохранён в базу данных. " +
                                      $"Имя пользователя: {update.Message.Chat.Username}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            var commands = _commandService.GetCommands();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(update, botClient, cancellationToken);
                    break;
                }
            }
        }
    }
}
