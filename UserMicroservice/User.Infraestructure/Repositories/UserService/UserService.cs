﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Infraestructure.Data;


namespace User.Infraestructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;

        public UserService(AppDbContext _context) => context = _context ;
               
        public void BlockUser(string email)
        {
            //Extraigo el usuario de la BD que estoy buscando segun el correo que
            //voy a bloquear
            var user = context.AppUsers.Where(x => x.Email == email).FirstOrDefault();
            //Actualizo la propiedad
            user.Blocked = true;
            
            //Actualizo el valor en la base de datos
            context.Update(user);

            context.SaveChanges();

        }

        public bool isItBlocked(string Email)
        {
            return context.AppUsers.Where(x => x.Email == Email).Select(x => x.Blocked).FirstOrDefault();                 
        }

        
    }
}
