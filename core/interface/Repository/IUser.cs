using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface IUser
    {
        bool AddUser(MUser User); 
        string GetUserRole(string Mobile);
        bool CheckExistUser(string Mobile);
        bool CheckExistUser(int Id);
        bool CheckActivateUser(string Mobile);
        String UpdatePassword(string Mobile,string Password,string NewPassword);
        bool UpdateUserRole(string Mobile,string Role);
        bool UpdateDetailUser(string Mobile,string FullName,string CodeMeli,bool IsActive);
        bool DeleteUser(int Id);
        MUser ShowDetailUser(string Mobile);
        MUser LoginUser(string mobile, string password);
        
    }
}