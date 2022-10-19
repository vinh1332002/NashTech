using assignment1.Models;
using assignment1.Data;

namespace assignment1.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentContext context) : base(context)
    {
    }
}