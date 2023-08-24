using StudentWebFormApp.Models;

namespace StudentWebFormApp.DAL
{
    public interface IStudentRespository
    {
        //Task<IEnumerable<Student>> GetStudents();
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        Task CreateStudent(Student student);
        int UpdateStudent(int id, Student student);
        void DeleteStudent(int id);
    }   
}
