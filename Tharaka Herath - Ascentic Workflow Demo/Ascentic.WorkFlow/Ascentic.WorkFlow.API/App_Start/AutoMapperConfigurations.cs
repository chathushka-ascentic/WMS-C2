using Ascentic.WorkFlow.Contracts.DTOs;
using Ascentic.WorkFlow.EndSystems.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ascentic.WorkFlow.API.App_Start
{
    public class AutoMapperConfigurations
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Task, TaskDto>().ReverseMap();
            });
        }
    }
}