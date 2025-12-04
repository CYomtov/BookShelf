using BookShelf.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Application.Interfaces
{
    public interface ILookupRepository
    {
        Task<List<GenreDto>> GetAllGenresAsync();
        Task<GenreDto?> GetGenreByIdAsync(int id);
        Task<GenreDto> CreateGenreAsync(CreateGenreDto dto);
        Task<GenreDto> UpdateGenreAsync(UpdateGenreDto dto);
        Task<bool> DeleteGenreAsync(int id);
        Task<List<StatusDto>> GetBookStatusAsync();
    }
}
