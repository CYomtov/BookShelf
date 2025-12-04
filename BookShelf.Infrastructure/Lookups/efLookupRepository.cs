using AutoMapper;
using BookShelf.Application.DTOs;
using BookShelf.Application.Interfaces;
using BookShelf.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Infrastructure.Lookups
{
    public class efLookupRepository : ILookupRepository
    {
        BookShelfDbContext _context;
        IMapper _mapper;

        public efLookupRepository(BookShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GenreDto>> GetAllGenresAsync()
        {
            var genres = await this._context.Genres.ToListAsync();

            return _mapper.Map<List<GenreDto>>(genres);
        }
        public async Task<GenreDto> CreateGenreAsync(CreateGenreDto dto)
        {
            var entity = _mapper.Map<Genre>(dto);
            _context.Genres.Add(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(_mapper.Map<GenreDto>(entity));

        }

        public async Task<GenreDto> UpdateGenreAsync(UpdateGenreDto dto)
        {
            var entity = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == dto.GenreId);
            if (entity == null)
            {
                throw new Exception("Genre not found");
            }
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(_mapper.Map<GenreDto>(entity));
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var entity = _context.Genres.Find(id);
            if (entity == null)
            {
                throw new Exception("Genre not found");
            }
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        

        public async Task<List<StatusDto>> GetBookStatusAsync()
        {
            var statuses = await this._context.BookStatuses.ToListAsync();
            return _mapper.Map<List<StatusDto>>(statuses);
        }

        public async Task<GenreDto?> GetGenreByIdAsync(int id)
        {
            var entity =   _context.Genres.Find(id);
            if (entity == null)
            {
                return await Task.FromResult<GenreDto?>(null);
            }
            return await Task.FromResult<GenreDto?>(_mapper.Map<GenreDto>(entity));
        }

        
    }
}
