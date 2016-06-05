// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="">
//   
// </copyright>
// <summary>
// Repository class
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DAL.EntityFramework.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// Repository class
	/// </summary>
	/// <typeparam name="T">
	/// </typeparam>
	public class Repository<T> : IRepository<T>
		where T : class
	{
		#region Fields

		private readonly DbContext context;

		private readonly IDbSet<T> entities;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of <see cref="Repository{T}"/> class
		/// </summary>
		/// <param name="context">
		/// Context
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		public Repository(DbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			this.context = context;
			entities = this.context.Set<T>();
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Add entity
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		public void Add(T entity)
		{
			try
			{
				if (entity == null)
				{
					throw new ArgumentNullException("entity");
				}

				entities.Add(entity);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Delete entity
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		public void Delete(T entity)
		{
			try
			{
				if (entity == null)
				{
					throw new ArgumentNullException("entity");
				}

				entities.Remove(entity);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Retrieve all entities
		/// </summary>
		/// <returns>
		/// <see cref="IEnumerable" />
		/// </returns>
		public IEnumerable<T> GetAll()
		{
			try
			{
				return entities.ToList();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Retrieve all entities specified by expressions
		/// </summary>
		/// <param name="includeExpressions">
		/// Include expressions
		/// </param>
		/// <returns>
		/// <see cref="IQueryable"/>
		/// </returns>
		public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeExpressions)
		{
			return includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(
				entities, 
				(current, expression) => current.Include(expression));
		}

		/// <summary>
		/// Retrieve entity specified by id
		/// </summary>
		/// <param name="id">
		/// Entity id
		/// </param>
		/// <returns>
		/// <see cref="T"/>
		/// </returns>
		public T GetById(object id)
		{
			try
			{
				return entities.Find(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Update entity
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		public void Update(T entity)
		{
			try
			{
				if (entity == null)
				{
					throw new ArgumentNullException("entity");
				}

				context.Entry(entity).State = EntityState.Modified;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		#endregion
	}
}