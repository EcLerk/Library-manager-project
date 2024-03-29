﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;

namespace library_manager.Application.Abstractions
{
    public interface IUserService:IBaseService<User>
    {
        public User CurrentUser { get; set; }
        public Task<User> GetByNameAsync(string name);
    }
}
