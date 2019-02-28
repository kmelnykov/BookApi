﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookMarketApi.Models;
using BookMarketApi.Resources;

namespace BookMarketApi.Mapping
{
    public class SaveBookToBookMap : Profile
    {
        public SaveBookToBookMap()
        {
            CreateMap<SaveBook, Book>();
        }

    }
}
