using FoodSharing.TelegramBot.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FoodSharing.TelegramBot.Commands
{
    public class StartCommand : ATelegramCommand
    {
        public override string Name => "/start";

        public override async Task Execute(Update update, ITelegramBotClient client, CancellationToken cancellationToken)
        {
            var chatId = update.Message.Chat.Id;
            ITelegramBot bot = new TelegramBot();
            bool isAdmin = await bot.CheckUserIsAdmin(chatId);

            if (isAdmin == true)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                    new KeyboardButton[] { "🥒 Поделиться едой 🥒"},
                    new KeyboardButton[] {  "🍅 Спасти еду 🍅" , "🌎 Мой аккаунт 🌎" },
                    new KeyboardButton[] { "🧩 Управление 🧩" },
                })
                {
                    ResizeKeyboard = true
                };

                await client.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Привет, админ! 🖖🏻\n\n" +
                    "Управление ботом доступно только администраторам.\n" +
                    "Чтобы перейти к управлению ботом, используй кнопку\n" +
                    "🧩 Управление 🧩\n\n" +
                    "🌳 Этот бот поможет тебе спасти кошелёк и планету. " +
                    "Поделись своей едой или забери то, что нужно тебе! 🌳",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
            }
            else
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                    new KeyboardButton[] { "🥒 Поделиться едой 🥒"},
                    new KeyboardButton[] {  "🍅 Спасти еду 🍅", "🌎 Мой аккаунт 🌎" },
                })
                {
                    ResizeKeyboard = true
                };

                await client.SendTextMessageAsync(
                    chatId: chatId,
                    text: "🌳 Этот бот поможет тебе спасти кошелёк и планету. " +
                    "Поделись своей едой или забери то, что нужно тебе! 🌳",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
            }
        }
    }
}
