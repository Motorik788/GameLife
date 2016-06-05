// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
// Class for controlling transactions flow
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DAL.EntityFramework.Transaction
{
	using System;
	using System.Collections.Generic;

    using System.Data.Entity;
    using Persistence;

	/// <summary>
	/// Class for controlling transactions flow
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		#region Fields

		public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

		private DbContext context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of <see cref="UnitOfWork"/> class
		/// </summary>
		/// <param name="context">
		/// Context
		/// </param>
		public UnitOfWork(Model1 context)
		{
			this.context = context;
            
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Commit changes to DB
		/// </summary>
		public void Commit()
		{
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Dispose DB context
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Get repository object
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <returns>
		/// <see cref="IRepository" />
		/// </returns>
		public IRepository<T> Repository<T>() where T : class
		{
			object repo;
			if (repositories.TryGetValue(typeof(T), out repo))
			{
				return (IRepository<T>)repo;
			}

			repo = new Repository<T>(context);
			repositories.Add(typeof(T), repo);

			return (IRepository<T>)repo;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Dispose db context
		/// </summary>
		/// <param name="disposing">
		/// Disposing flag
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
			{
				return;
			}

			if (context == null)
			{
				return;
			}

			context.Dispose();
			context = null;
		}

		#endregion
	}
}