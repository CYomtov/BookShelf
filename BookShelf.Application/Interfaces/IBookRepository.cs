using BookShelf.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<BookDto> UpdateAsync(UpdateBookDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
