using System;
using Database.Entities;

namespace StudentBusinessRules {
    public static class BusinessRules
    {
        
        public static bool isLowEnrollment(Student student) => 
            Student.StudentCount < lowEnrollmentCount;

        public static bool isSpecial(Student student){
           bool isSpecial = false;
           if(student.StudentId < 10){
               isSpecial = true;
           }
            return isSpecial;
        }
            


        public static int lowEnrollmentCount = 1;
        //public static string onSaleKey = "b";
    }
}