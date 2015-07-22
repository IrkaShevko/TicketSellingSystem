using System;
using AutoMapper;
using TicketSellingSystemInfrastructure.Models.EFModels;
using TicketSellingSystemInfrastructure.Models.ViewModels;
using TicketSellingSystemInfrastructure.Models.ViewModels.UserModels;

namespace TicketSellingSystem
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ApplicationProfile>(); });
        }
    }

    public class ApplicationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<LoginViewModel, User>();

            CreateMap<RegisterViewModel, User>();

            CreateMap<User, AdminUserModel>();

            CreateMap<Film, FilmViewModel>();

            CreateMap<Session, SessionViewModel>();

            CreateMap<Recall, RecallViewModel>();

            CreateMap<Cinema, CinemaViewModel>();

            CreateMap<User, UserViewModel>()
                .ForMember(
                    e => e.Roles,
                    u => u.ResolveUsing<SplitStringResolver>()
                        .FromMember(e => e.Roles));
        }
    }

    public class SplitStringResolver : ValueResolver<string, string[]>
    {
        protected override string[] ResolveCore(string source)
        {
            return source.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}