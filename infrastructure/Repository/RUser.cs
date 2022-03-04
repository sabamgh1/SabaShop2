using System;
using System.Collections.Generic;
using AutoMapper;
using core.Domain;
using core.Repository;
using infrastructure.Data.Context;
using infrastructure.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class RUser : IUser
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RUser(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }

        public bool AddUser(MUser User)
        {
            User user = new User()
            {
                Mobile = User.Mobile,
                Password = User.Password,
                CodeMeli = User.CodeMeli,
                Date = DateTime.Now,
                FullName = User.FullName,
                IsActive = false,
                Role = "کاربر"

            };
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool CheckActivateUser(string Mobile)
        {
            var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile).IsActive;
            return select;
        }

        public bool CheckExistUser(string Mobile)
        {
            if (context.Users.Any(u => u.Mobile == Mobile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckExistUser(int Id)
        {
            if (context.Users.Any(u => u.Id == Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int Id)
        {
            if (CheckExistUser(Id))
            {
                context.Users.Remove(context.Users.SingleOrDefault(u => u.Id == Id));
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetUserRole(string Mobile)
        {
            if (CheckExistUser(Mobile))
            {
                var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile).Role;
                return select;
            }
            else
            {
                return null;
            }
        }

        public MUser ShowDetailUser(string Mobile)
        {
            if (CheckExistUser(Mobile))
            {
                var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile);
                var User = iMap.Map<MUser>(select);
                return User;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateDetailUser(string Mobile, string FullName, string CodeMeli, bool IsActive)
        {
            if (CheckExistUser(Mobile))
            {
                var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile);
                select.FullName = FullName;
                select.CodeMeli = CodeMeli;
                select.IsActive = IsActive;

                context.Users.Update(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public String UpdatePassword(string Mobile, string Password, string NewPassword)
        {
            var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile && u.Password == Password);
            var R="";
            if (select != null)
            {
                R = "1";
                select.Password = NewPassword;
                context.Users.Update(select);
                context.SaveChanges();
                return R;
            }
            else
            {
                R="2";
                return R;
            }

        }

        public bool UpdateUserRole(string Mobile, string Role)
        {
            if (CheckExistUser(Mobile))
            {
                var select = context.Users.SingleOrDefault(u => u.Mobile == Mobile);
                select.Role = Role;
                context.Users.Update(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public MUser LoginUser(string mobile, string password)
        {
            var select = context.Users.FirstOrDefault(u => u.Mobile == mobile && u.Password == password);
            if (select.IsActive == true && select.Role == "کاربر")
            {
                var user = iMap.Map<MUser>(select);
                return user;
            }
            else
            {
                return null;
            }

        }

    }
}