﻿using Microsoft.EntityFrameworkCore;
using proyecto_final_prog2.Application.Dtos.Tags;
using proyecto_final_prog2.Domain.Entities;
using proyecto_final_prog2.Infrastructure;
using proyecto_final_prog2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Services
{
    public class TagService
    {
        private readonly AppDBContext _context;

        public TagService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _context.tags.ToListAsync();
        }

        public async Task<Tag?> GetTagFromDB(int id)
        {
            return await _context.tags.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<IndexTagDto?> GetTag(int id)
        {
            Tag? tag = await GetTagFromDB(id);
            if (tag != null)
            {
                return new IndexTagDto { ID=id, tag_name = tag.tag_name };
            }
            return null;
        }

        public async Task<List<Tag>> GetTagsFromTask(int id)
        {
            Domain.Entities.Task? tsk = await _context.tasks.Include(t => t.tags).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            List<Tag> res = new List<Tag>();

            if (tsk != null)
            {
                return tsk.tags.ToList();
            }
            return new List<Tag>(); //esto es lo que la falta de tiempo hace xD
        }
        

        public async Task<bool> TagExistsByName(string name)
        {
            return (await _context.tags.AnyAsync(t => t.tag_name == name));
        }

        public async Task<Tag> CreateTag(CreateTagDto tagModel, int task_id)
        {
            Domain.Entities.Task? tsk = await _context.tasks.FirstOrDefaultAsync(x=>x.ID==task_id);
            //Domain.Entities.Task? tsk = await _context.tasks.Include(t => t.tags).AsNoTracking().FirstOrDefaultAsync(x => x.ID == task_id);
            Tag tag = new Tag
            {
                tag_name = tagModel.tag_name
            };
            tsk.tags.Add(tag);
            /*tag.tasks.Add(tsk);
            _context.tasks.Update(tsk);
            await _context.tags.AddAsync(tag);*/
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> UpdateTag(int id, UpdateTagDto tagModel)
        {
            Tag? tag = await GetTagFromDB(id);
            if (tag != null)
            {
                tag.tag_name = tagModel.tag_name;
                _context.tags.Update(tag);
                await _context.SaveChangesAsync();
            }
            return tag;
        }

        public async Task<Tag?> DeleteTag(int id)
        {
            Tag? tag = await GetTagFromDB(id);
            if (tag != null)
            {
                _context.tags.Remove(tag);
            }
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
