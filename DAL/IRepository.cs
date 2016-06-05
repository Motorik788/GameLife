// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
//   
// </copyright>
// <summary>
// Use it to improve the code's maintainability and readability by separating business logic from data access logic
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DAL
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// Use it to improve the code's maintainability and readability by separating business logic from data access logic
	/// </summary>
	/// <typeparam name="T">
	/// </typeparam>
	public interface IRepository<T>
		where T : class
	{
		#region Public Methods and Operators

		/// <summary>
		/// Add entity for further submitting by commit method of Unit Of Work
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		void Add(T entity);

		/// <summary>
		/// Delete entity for further submitting by commit method of Unit Of Work
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		void Delete(T entity);

		/// <summary>
		/// Retrieve all entities
		/// </summary>
		/// <returns>
		/// List of entities
		/// </returns>
		IEnumerable<T> GetAll();

		/// <summary>
		/// Retrieve all entities specified by template
		/// </summary>
		/// <param name="includeExpressions">
		/// Include expressions
		/// </param>
		/// <returns>
		/// <see cref="IQueryable"/>
		/// </returns>
		IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeExpressions);

		/// <summary>
		/// Retrieve entity specified by id
		/// </summary>
		/// <param name="id">
		/// Entity id
		/// </param>
		/// <returns>
		/// <see cref="T"/>
		/// </returns>
		T GetById(object id);

		/// <summary>
		/// Update entity for further submitting by commit method of Unit Of Work
		/// </summary>
		/// <param name="entity">
		/// Entity
		/// </param>
		void Update(T entity);

		#endregion
	}
}