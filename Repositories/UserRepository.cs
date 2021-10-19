﻿using Microsoft.EntityFrameworkCore;
using mylastplaylist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Repositories
{
    public class UserRepository 
    { 
        private readonly PlaylistDbContext _playlistDbContext;
        public readonly DbSet<User> _dbSet;
    
        public UserRepository(PlaylistDbContext playlistcontext)
        {
            _playlistDbContext = playlistcontext;
            _dbSet = _playlistDbContext.Set<User>();
        }



    }       
}
