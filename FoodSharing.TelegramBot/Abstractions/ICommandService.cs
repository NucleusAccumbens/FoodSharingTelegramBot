using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.TelegramBot.Abstractions
{
    public interface ICommandService
    {
        List<ATelegramCommand> GetCommands();
    }
}
