using AutoMapper;
using BookShelf.Application.DTOs;
using BookShelf.Application.Interfaces;
using BookShelf.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Infrastructure.Books
{
    public class EfBookRepository : IBookRepository
    {
        private readonly BookShelfDbContext _context;
        private readonly IMapper _mapper;

        public EfBookRepository(BookShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            // For now, we’ll keep explicit Include + projection,
            // AutoMapper is more useful on the create/update side.
            var query = _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Status);

            var entities = await query.ToListAsync();

            return _mapper.Map<List<BookDto>>(entities);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (entity == null)
                return null;

            return _mapper.Map<BookDto>(entity);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var now = DateTime.UtcNow;

            var entity = _mapper.Map<Book>(dto);
            entity.CreatedAt = now;
            entity.UpdatedAt = now;

            _context.Books.Add(entity);
            await _context.SaveChangesAsync();

            // load related data so DTO has Genre/Status filled
            await _context.Entry(entity).Reference(b => b.Genre).LoadAsync();
            await _context.Entry(entity).Reference(b => b.Status).LoadAsync();

            return _mapper.Map<BookDto>(entity);
        }

        public async Task<BookDto> UpdateAsync(UpdateBookDto dto)
        {
            var entity = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(b => b.Id == dto.Id);

            if (entity == null)
                throw new KeyNotFoundException($"Book with id {dto.Id} not found.");

            // Overlay DTO values onto the existing entity
            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Make sure related data is available
            await _context.Entry(entity).Reference(b => b.Genre).LoadAsync();
            await _context.Entry(entity).Reference(b => b.Status).LoadAsync();

            return _mapper.Map<BookDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Books.FindAsync(id);
            if (entity == null)
                return false;

            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
