﻿using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implimentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieManagementDbContext _context;

        public UnitOfWork(MovieManagementDbContext context)
        {
            _context = context;
            Actor = new ActorRepository(_context);
            Movie = new MovieRepository(_context);
            Genre = new GenreRepository(_context);
            Biography = new BiographyRepository(_context);
        }

        public IActorRepository Actor { get; private set; }

        public IMovieRepository Movie { get; private set; }

        public IGenreRepository Genre { get; private set; }

        public IBiographyRepository Biography { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
