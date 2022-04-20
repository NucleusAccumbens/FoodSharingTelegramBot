using FoodSharing.BusinessLogicLayer.DataTransferObject;
using FoodSharing.BusinessLogicLayer.Services;
using FoodSharing.DataAccessLayer;
using FoodSharing.DataAccessLayer.Interfaces;
using FoodSharing.TelegramBot.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FoodSharing.TelegramBot
{
    public class TelegramBot : ITelegramBot
    {
        private static readonly string _token 
            = "5348807851:AAE9mMG6oh_s_B4MGq7XYMj5UzRh9S88Fpk";
        private readonly ITelegramBotClient _botClient = new TelegramBotClient(_token);
        private readonly ICommandAnalyzer _commandAnalyzer = new CommandAnalyzer();

        public async Task<bool> CheckUserIsAdmin(long chatId)
        {
            try
            {
                UnitOfWork repo = new UnitOfWork();
                var userService = new UserService(repo);
                return await userService.CheckUserIsAdmin(chatId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveUserInDb(Update ubdate)
        {
            try
            {
                bool userIsInDb = await CheckUserIsInDb(ubdate);

                if (userIsInDb == true)
                {
                    return false;
                }
                else
                {
                    UnitOfWork repo = new UnitOfWork();
                    var userService = new UserService(repo);
                    var user = new UserDto()
                    {
                        ChatId = ubdate.Message.Chat.Id,
                        Username = ubdate.Message.Chat.Username,
                        Firstname = ubdate.Message.Chat.FirstName,
                        Lastname = ubdate.Message.Chat.LastName,
                        IsAdmin = false,
                    };

                    await userService.CreateAsync(user);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private async Task<bool> CheckUserIsInDb(Update ubdate)
        {
            try
            {
                long chatId = ubdate.Message.Chat.Id;
                IUnitOfWork _unit = new UnitOfWork();
                var userService = new UserService(_unit);

                return await userService.CheckUserIsInDb(chatId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string StartReceiving()
        {
            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

            _botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = _botClient.GetMeAsync().Result;

            return $"Начал принимать обновления из чатов с ботом @{me.Username}";
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await _commandAnalyzer.AnalyzeCommand(botClient, update, cancellationToken, this);
        }

        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Ошибка Telegram API:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            return Task.CompletedTask;
        }
    }
}
