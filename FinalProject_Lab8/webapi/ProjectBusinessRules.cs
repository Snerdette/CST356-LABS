using System;
using Database.Entities;

namespace ProjectBusinessRules {
    public class BusinessRules
    {
        
        /* public static bool isLowEnrollment(Project project) => 
            Project.ProjectCount < lowEnrollmentCount;
        */
        public bool isGroupProject(Project project){
            if(project.Type == "Group"){
                return true;
            } else {
                return false;
            }
        }
            


        public static int lowEnrollmentCount = 1;
        //public static string onSaleKey = "b";
    }
}