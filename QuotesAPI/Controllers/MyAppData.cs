﻿using QuotesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Controllers
{
    /// <summary>
    /// Для сохранения данных и состояния приложения между запросами.
    /// Использовал Dependency Injection, чтобы сделать данные доступными для всех пользователей:
    /// </summary>
    public class MyAppData
    {
        public List<QuoteModel> quotes=new List<QuoteModel>();

        public List<QuoteModel> QuotesByCategory(string category)
        {
            return this.quotes.FindAll((QuoteModel q) => { return q.Category.ToLower() == category.ToLower(); });
        }
        public QuoteModel RandomQuote()
        {
            int RandomId = new Random().Next(0, this.quotes.Count);
            return this.quotes[RandomId];
        }

        public void AddQuote(QuoteModel value)
        {
            value.CreationTime = DateTime.Now;
            value.EditTime = DateTime.Now;
            this.quotes.Add(value);
        }

        public void UpdateQuote(int id, QuoteModel value)
        {
            var creationTime = this.quotes[id].CreationTime;
            this.quotes[id] = value;
            this.quotes[id].EditTime = DateTime.Now;
            this.quotes[id].CreationTime = creationTime;
        }

        public bool Exists(int id)
        {
            return (id < this.quotes.Count && id > -1);
        }
    }
}
