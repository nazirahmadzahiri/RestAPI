using AutoMapper;
using RestAPI.Dtos;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestAPI.Profiles
{
    public class CommandProfile :Profile
    {
        public CommandProfile()
        {
            //source -> target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
