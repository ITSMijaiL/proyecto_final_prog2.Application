using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using proyecto_final_prog2.Application.Dtos.Columns;
using proyecto_final_prog2.Application.Dtos.Tags;
using proyecto_final_prog2.Application.Dtos.Tasks;
using proyecto_final_prog2.Infrastructure.Models;
using Refit;

namespace proyecto_final_prog2.Application
{
    public interface IApiClient
    {
        [Get("/api/Columns")]
        public Task<List<Domain.Entities.Column>> GetColumns();
        [Get("/api/Columns/{id}")]
        public Task<IndexColumnDto?> GetColumn(int id);
        [Post("/api/Columns")]
        public Task CreateColumn([Body] ColumnModel columnModel);
        [Put("/api/Columns/{id}")]
        public Task UpdateColumn(int id, [Body] ColumnModel columnModel);
        [Delete("/api/Columns/{id}")]
        public Task DeleteColumn(int id);

        [Get("/api/Tags")]
        public Task<List<Domain.Entities.Tag>> GetTags();
        [Get("/api/Tags/{id}")]
        public Task<IndexTagDto?> GetTag(int id);
        [Post("/api/Tags")]
        public Task CreateTag([Body] TagModel tagModel);
        [Put("/api/Tags/{id}")]
        public Task UpdateTag(int id, [Body] TagModel tagModel);
        [Delete("/api/Tags/{id}")]
        public Task DeleteTag(int id);


        [Get("/api/Tasks")]
        public Task<List<Domain.Entities.Task>> GetTasks();
        [Get("/api/Tasks/{id}")]
        public Task<IndexTaskDto?> GetTasksFromColumn(int id);
        [Post("/api/Tasks")]
        public Task CreateTask([Body] TaskModel taskModel);
        [Put("/api/Tasks/{id}")]
        public Task UpdateTask(int id, [Body] TaskModel taskModel);
        [Delete("/api/Tasks/{id}")]
        public Task DeleteTask(int id);
    }
}
