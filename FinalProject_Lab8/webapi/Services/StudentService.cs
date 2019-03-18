using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Database.Entities;
using StudentBusinessRules;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRespository;
    private readonly ILogger _logger;

    public StudentService(IStudentRepository studentRepository, ILoggerFactory loggerFactory)
    {
        _studentRespository = studentRepository;
        _logger = loggerFactory.CreateLogger("Controllers.StudentService");
    }

    public List<StudentDto> GetAllStudents()
    {
        var studentDtos = new List<StudentDto>();
        var studentCount = 0;

        foreach(var student in _studentRespository.GetAllStudents())
        {
            studentDtos.Add(new StudentDto {
                StudentId = student.StudentId,
                Email_Address = student.Email
            });
            if (BusinessRules.isLowEnrollment(student))
            {
                _logger.LogInformation("Found low inventory student: " + student.StudentId);
            }
            studentCount++;
        }

        return studentDtos;
    }

    public Student GetStudentById(long studentId)
    {
        return _studentRespository.GetStudentById(studentId);
    }
     
    public bool GetSpecial(long studentId)
    {
        var student = GetStudentById(studentId);
        if(student.StudentId < 10){
            return true;
        } else {
            return false;
        }
        
    }
    
    public void AddStudent(Student student)
    {
        _studentRespository.AddStudent(student);
    }

    public void UpdateStudent(Student student)
    {
        _studentRespository.UpdateStudent(student);
    }

    public void DeleteStudent(long studentId)
    {
        _studentRespository.DeleteStudent(studentId);
    }
}