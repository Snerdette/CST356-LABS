using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database;
using Database.Entities;
using System;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _dbContext;
    private readonly ILogger _logger;

    public StudentRepository(SchoolContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _logger = loggerFactory.CreateLogger("Controllers.StudentRepository");
    }

    public List<Student> GetAllStudents()
    {
        try
        {
            return _dbContext.Student.ToList();
        } 
        catch(Exception ex)
        {
            _logger.LogError("Failed to get ersons.", ex);
            
            return new List<Student>();
        }
    }

    public Student GetStudentById(long studentId)
    {
        return _dbContext.Student.SingleOrDefault(p => p.StudentId == studentId);
    }

    public void AddStudent(Student student)
    {
        _dbContext.Student.Add(student);
        _dbContext.SaveChanges();
    }

    public void UpdateStudent(Student studentUpdate)
    {
        var student = GetStudentById(studentUpdate.StudentId);

        if (student != null)
        {
            student.Email = studentUpdate.Email;


            _dbContext.Update(student);

            _dbContext.SaveChanges();
        }
    }

    public void DeleteStudent(long studentId)
    {
        var student = new Student { StudentId = studentId };

        _dbContext.Student.Attach(student);
        _dbContext.Student.Remove(student);
        _dbContext.SaveChanges();
    }
}