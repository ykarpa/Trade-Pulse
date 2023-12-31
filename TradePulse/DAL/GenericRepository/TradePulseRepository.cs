﻿using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.GenerickRepository
{
	public class TradePulseRepository<T> : IGenericRepository<T> where T : class
	{
		private TradePulseContext context;
		private DbSet<T> table;
		public TradePulseRepository()
		{
			context = new TradePulseContext();
			table = context.Set<T>();
		}
		public async Task Create(T entity)
		{
			await this.table.AddAsync(entity);
		}

		public IQueryable<T> GetQueryable()
		{
			return this.table.AsQueryable<T>();
		}

		public void Delete(T entity)
		{
			table.Remove(entity);
		}

		public Task<List<T>> GetAll()
		{
			return table.ToListAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await table.FindAsync(id);
		}

		public void Save()
		{
			this.context.SaveChanges();
		}

		public void Update(T entity)
		{
			table.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}
	}
}
