// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="">
//   
// </copyright>
// <summary>
// Base interface for all services
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL
{
	using DAL;

	/// <summary>
	/// Base interface for all services
	/// </summary>
	public interface IService
	{
		#region Public Properties

		/// <summary>
		/// UnitOfWork
		/// </summary>
		IUnitOfWork unitOfWork { get; set; }

		#endregion
	}
}