using FoodSharing.TelegramBot.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FoodSharing.TelegramBot
{
    internal class Program
    {
        private static readonly ITelegramBot _bot = new TelegramBot();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(_bot.StartReceiving());
                Thread.Sleep(int.MaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
