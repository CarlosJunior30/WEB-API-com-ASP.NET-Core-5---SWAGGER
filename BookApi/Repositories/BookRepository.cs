﻿using BooksApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async  Task<Book> Create(Book book)//Criacao de livro
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)//Excluir excluisvamente um livro
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get() // Busca e tras o registro especifico
        {
           return await _context.Books.ToListAsync();
            
        }

        public async Task<Book> Get(int id) // Busca específica de Id
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task Update(Book book)//Atualizacao de Book no bd
        {
           _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
