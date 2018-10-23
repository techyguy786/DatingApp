using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Services {
    public class ValuesService {
        private readonly DataContext _context;
        public ValuesService(DataContext context) => this._context = context;

        public async Task<IEnumerable<Value>> GetValues() => await _context.Values.ToListAsync();

        public async Task<Value> GetValue(int id) => await _context.Values.SingleOrDefaultAsync(x => x.Id == id);
    }
}