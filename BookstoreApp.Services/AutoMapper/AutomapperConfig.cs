﻿using AutoMapper;
using BookstoreApp.Services.AutoMapper.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BookstoreApp.Services.AutoMapper
{
    public static class AutomapperConfig
    {
        // Not automatic automapper
        //public static void Initialize()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<BookModel, Book>().ReverseMap();
        //    });
        //}
        public static void Initialize()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => !x.IsDynamic)
                .SelectMany(x => x.GetReferencedAssemblies())
                .Select(x => Assembly.Load(x))
                .SelectMany(x => x.GetTypes());
            
            Mapper.Initialize(cfg => Load(types, cfg));
        }


        private static void Load(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            LoadStandardMappings(types, cfg);
            LoadCustomMappings(types, cfg);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var typesFoundForMapping = types
                  .Where(t => !t.IsInterface && !t.IsAbstract)
                  .Where(t => t.GetInterfaces()
                          .Any(i => i.IsGenericType &&
                               i.GetGenericTypeDefinition().Equals(typeof(IMapFrom<>)))).ToList().Select(x => new
                               {
                                   source = x,
                                   dest = x.GetInterfaces().FirstOrDefault(y => y.GetGenericTypeDefinition() == typeof(IMapFrom<>)).GetGenericArguments()[0]
                               });

            foreach (var type in typesFoundForMapping)
            {
                cfg.CreateMap(type.source, type.dest).ReverseMap();
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var typesFoundForMapping = types
                  .Where(t => !t.IsInterface && !t.IsAbstract)
                  .Where(t => t.GetInterfaces().Any(i => typeof(IHaveCustomMappings).IsAssignableFrom(i)))
                          .Select(x => (IHaveCustomMappings)Activator.CreateInstance(x)).ToArray();


            foreach (var type in typesFoundForMapping)
            {
                type.CreateMappings(cfg);
            }
        }

        public static void Reset()
        {
            Mapper.Reset();
        }
    }
}
