using AllTheCommands.Models;
using AllTheCommands.ViewModels;
using AutoMapper;

namespace AllTheCommands.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Map From Model -> ViewModel. We dont want to show users everything in the model, eks ID
            CreateMap<Command, CommandsViewModel>();
            // Map from the ViewModel -> Model. We take the information the users supplied and map it to our model
            CreateMap<CommandCreateViewModel, Command>();
            CreateMap<CommandUpdateViewModel, Command>();
            CreateMap<Command, CommandUpdateViewModel>();

        }
    }
}
