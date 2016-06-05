namespace DAL
{
	using System.Data.Entity;

	public class DataContext : DbContext
	{
		public DataContext()
			: base("name=DataContext")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Score> Scores { get; set; }

		public virtual DbSet<Student> Students { get; set; }

		public virtual DbSet<Subject> Subjects { get; set; }       
        
	}

	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class Subject
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class Score
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int SubjectId { get; set; }
		public int ScoreNumber { get; set; }
	}


}