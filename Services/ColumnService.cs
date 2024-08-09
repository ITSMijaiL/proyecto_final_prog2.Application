using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyecto_final_prog2.Application.Dtos.Columns;
using proyecto_final_prog2.Domain.Entities;
using proyecto_final_prog2.Infrastructure;
using proyecto_final_prog2.Infrastructure.Models;


namespace proyecto_final_prog2.Application.Services
{
    public class ColumnService
    {
        private readonly AppDBContext _context;

        public ColumnService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Column>> GetColumns()
        {
            return await _context.columns.ToListAsync();
        }

        public async Task<Column?> GetColumnFromDB(int id)
        {
            return await _context.columns.FirstOrDefaultAsync(c => c.ID == id);
        }
        public async Task<Column?> GetColumnFromDBUsingTitle(string title)
        {
            return await _context.columns.FirstOrDefaultAsync(c => c.column_title == title);
        }

        public async Task<IndexColumnDto?> GetColumn(int id)
        {
            Column col = await GetColumnFromDB(id);
            if (col != null)
            {
                return new IndexColumnDto { ID=id, column_title = col.column_title };
            }
            return null;
        }

        public async Task<int?> GetColumnID(string title)
        {
            Column col = await GetColumnFromDBUsingTitle(title);
            if (col != null)
            {
                return col.ID;
            }
            return null;
        }

        public async Task<Column> CreateColumn(CreateColumnDto columnModel)
        {
            Column column = new Column
            {
                column_title = columnModel.column_title
            };

            await _context.columns.AddAsync(column);
            await _context.SaveChangesAsync();
            return column;
        }

        //public async Task<Column?> UpdateColumn(int id, UpdateColumnDto columnModel)
        public async Task<Column?> UpdateColumn(int id, Column columnModel)
        {
            Column? column = await GetColumnFromDB(id);
            if (column != null) {
                column.column_title = columnModel.column_title;
                column.tasks = columnModel.tasks;
                _context.columns.Update(column);
                await _context.SaveChangesAsync();
            }
            return column;
        }

        public async Task<Column?> DeleteColumn(int id)
        {
            Column? column = await GetColumnFromDB(id);
            if (column != null)
            {
                _context.tasks.RemoveRange(_context.tasks.Where(x=>x.ColumnID==id).ToList());
                _context.columns.Remove(column);
            }
            await _context.SaveChangesAsync();
            return column;
        }
    }
}
