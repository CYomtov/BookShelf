using BookShelf.Application.DTOs;
using BookShelf.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Infrastructure.Lookups
{
    public class efLookupRepository : ILookupRepository
    {
        public efLookupRepository()
        {
        }

        public Task<GenreDto> CreateGenreAsync(CreateGenreDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGenreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GenreDto>> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusDto>> GetBookStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto?> GetGenreByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto> UpdateGenreAsync(UpdateGenreDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
