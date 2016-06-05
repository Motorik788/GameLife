// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
// Maintains a list of objects affected by a business transaction and coordinates writing out the changes
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DAL
{
	using System;

	/// <summary>
    /// Maintains a list of objects affected by a business transaction and coordinates writing out the changes
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		#region Public Methods and Operators

		/// <summary>
		/// Perform saving of changes to database for entire context
		/// </summary>
		void Commit();

		/// <summary>
		/// Repository object
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <returns>
		/// <see cref="IRepository" />
		/// </returns>
		IRepository<T> Repository<T>() where T : class;

		#endregion
	}
}