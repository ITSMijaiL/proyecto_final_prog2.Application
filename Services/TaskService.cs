using Microsoft.EntityFrameworkCore;
using proyecto_final_prog2.Application.Dtos.Tasks;
using proyecto_final_prog2.Domain.Entities;
using proyecto_final_prog2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Services
{
    public class TaskService
    {
        private readonly AppDBContext _context;

        public TaskService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Task>> GetTasks()
        {
            return await _context.tasks.ToListAsync();
        }

        public async Task<List<Domain.Entities.Task>> GetTasksFromColumn(int id)
        {
            Column? col = await _context.columns.FirstOrDefaultAsync(x => x.ID == id);
            List<Domain.Entities.Task> res = new List<Domain.Entities.Task>();
            if (col!=null) {
                res = await _context.tasks.Where(x => x.ColumnID == id).ToListAsync();
            }
            return res;
        }

        public async Task<Domain.Entities.Task?> GetTaskFromDB(int id)
        {
            return await _context.tasks.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<IndexTaskDto?> GetTask(int id)
        {
            Domain.Entities.Task? task = await GetTaskFromDB(id);
            if (task != null)
            {
                return new IndexTaskDto { ID = id, text = task.text, title = task.title };
            }
            return null;
        }

        public async Task<Domain.Entities.Task> CreateTask(CreateTaskDto taskModel, int column_id)
        {
            Column? c = await _context.columns.FirstOrDefaultAsync(x => x.ID == column_id);
            Domain.Entities.Task task = new Domain.Entities.Task
            {
                title = taskModel.title,
                text = taskModel.text
            };

            task.ColumnID = column_id;
            await _context.tasks.AddAsync(task);
            //c.tasks.Add(task);
            //_context.columns.Update(c);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Domain.Entities.Task?> UpdateTask(int id, UpdateTaskDto taskModel)
        {
            Domain.Entities.Task? task = await GetTaskFromDB(id);
            if (task != null)
            {
                task.text = taskModel.text;
                task.title = taskModel.title;
                _context.tasks.Update(task);
                await _context.SaveChangesAsync();
            }
            return task;
        }

        public async Task<Domain.Entities.Task?> DeleteTask(int id)
        {
            Domain.Entities.Task? task = await GetTaskFromDB(id);
            if (task != null)
            {
                _context.tasks.Remove(task);
            }
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
