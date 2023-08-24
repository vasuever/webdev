using Dapper;
using StudentWebFormApp.DAL;
using StudentWebFormApp.Models;

namespace StudentWebFormApp.Repository
{
    public class StudentRespository:IStudentRespository
    {
        private readonly DapperDBContext dbContext;

        public StudentRespository(DapperDBContext dapperDBContext)
        {
            this.dbContext = dapperDBContext;
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                var query = "SELECT * FROM StudentTbl";

                using (var connection = dbContext.CreateConnection())
                {
                    var students = connection.Query<Student>(query);
                    return students.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Student GetStudent(int id)
        {
            try
            {
                var query = "SELECT * FROM StudentTbl WHERE StudentID = @Id";

                using (var connection = dbContext.CreateConnection())
                {
                    var student = connection.QuerySingleOrDefault<Student>(query, new { id });
                    return student;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task CreateStudent(Student student)
        {
            try
            {
                var query = "INSERT INTO StudentTbl (StudentID, FirstName, LastName, SSN, FatherName, MotherName, Address, City)" +
                    " VALUES (@StudentID, @FirstName, @LastName, @SSN, @FatherName, @MotherName, @Address, @City)";

                using (var connection = dbContext.CreateConnection())
                {
                    await connection.ExecuteAsync(query, new
                    {
                        student.StudentID,
                        student.FirstName,
                        student.LastName,
                        student.SSN,
                        student.FatherName,
                        student.MotherName,
                        student.Address,
                        student.City
                    });
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }
       
        public int UpdateStudent(int id, Student student)
        {
            try
            {
                var query = "UPDATE StudentTbl SET FirstName = @FirstName, LastName = @LastName,SSN = @SSN,FatherName = @FatherName, " +
                    " MotherName = @MotherName, Address = @Address,City = @City WHERE StudentID = @Id";
                using (var connection = dbContext.CreateConnection())
                {
                    int RowsEffected = connection.Execute(query, new
                    {
                        student.FirstName,
                        student.LastName,
                        student.SSN,
                        student.FatherName,
                        student.MotherName,
                        student.Address,
                        student.City,
                        id
                    });

                    return RowsEffected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void DeleteStudent(int id)
        {
            try
            {
                var query = "DELETE FROM StudentTbl WHERE StudentID = @Id";
                using (var connection = dbContext.CreateConnection())
                {
                    connection.Execute(query, new { id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
