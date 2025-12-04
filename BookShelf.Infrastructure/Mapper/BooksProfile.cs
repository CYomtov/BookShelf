using AutoMapper;
using BookShelf.Application.DTOs;
using BookShelf.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Infrastructure.Mapper
{
    public class BooksProfile : Profile
    {

        public BooksProfile()
        {
            // Entity -> DTO
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Genre,
                    opt => opt.MapFrom(src => src.Genre != null ? src.Genre.GenreName : null))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.StatusName));

            // Create DTO -> Entity
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            // Update DTO -> Entity
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            // Genre Entity -> DTO
            CreateMap<Genre, GenreDto>().ReverseMap();

            // Genre Update DTO -> Entity
            CreateMap<UpdateGenreDto, Genre>().ReverseMap();

            // Genre Create DTO -> Entity
            CreateMap<CreateGenreDto, Genre>().ReverseMap();

            // Status Entity -> DTO
            CreateMap<BookStatus, StatusDto>().ReverseMap();
        }


    }
}
