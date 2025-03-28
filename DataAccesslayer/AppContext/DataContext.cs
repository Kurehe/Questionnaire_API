﻿using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.AppContext
{
    internal class DataContext : DbContext
    {
        /// <summary>
        /// Анкета
        /// </summary>
        public DbSet<Survey> Surveys { get; set; }
        /// <summary>
        /// Вопросы
        /// </summary>
        public DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Ответы на вопросы
        /// </summary>
        public DbSet<Answer> Answers { get; set; }
        /// <summary>
        /// Респонденты
        /// </summary>
        public DbSet<Interview> Interviews { get; set; }
        /// <summary>
        /// Результаты ответов респондентов
        /// </summary>
        public DbSet<Result> Results { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Используем существующую бд (если она конечно есть)
            //Database.EnsureCreated();
        }
    }
}
