using AllTheCommands.Models;
using AllTheCommands.ViewModels;
using AutoMapper;

namespace AllTheCommands.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandsViewModel>();
        }
    }
}
