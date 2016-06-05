// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentService.cs" company="">
//   
// </copyright>
// <summary>
// Student service class for adding layer between UI and DAL
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using DAL;

	/// <summary>
	/// Student service class for adding layer between UI and DAL
	/// </summary>
	public class SaveService<T> : IService where T: class
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of <see cref="SaveService"/> class
		/// </summary>
		/// <param name="unitOfWork">
		/// Unit of work
		/// </param>
		public SaveService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets unit of work
		/// </summary>
		public IUnitOfWork unitOfWork { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Add student
		/// </summary>
		/// <param name="save">
		/// Student
		/// </param>
		public void Add(T save)
		{
			try
			{
				unitOfWork.Repository<T>().Add(save);

				unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Update student
		/// </summary>
		/// <param name="save">
		/// Student
		/// </param>
		public void Update(T save)
		{
			try
			{
				unitOfWork.Repository<T>().Update(save);

				unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Delete student
		/// </summary>
		/// <param name="id">
		/// Student id
		/// </param>
		public void Delete(int id)
		{
			try
			{
				IRepository<T> studentRepo = unitOfWork.Repository<T>();
				T save = null;

				if (studentRepo != null)
				{
					save = unitOfWork.Repository<T>().GetById(id);
				}

				if (save != null)
				{
					studentRepo.Delete(save);
				}

				unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// Get list of students
		/// </summary>
		/// <returns>
		/// <see cref="IEnumerable" />
		/// </returns>
		public IEnumerable<T> GetAll()
		{
			return unitOfWork.Repository<T>().GetAll();
		}

		/// <summary>
		/// Get student by id
		/// </summary>
		/// <param name="id">
		/// Student id
		/// </param>
		/// <returns>
		/// <see cref="Student"/>
		/// </returns>
		public T GetById(int id)
		{
			return unitOfWork.Repository<T>().GetById(id);
		}

		#endregion
	}
}