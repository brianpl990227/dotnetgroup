using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Auth.User;
using User.Domain.Repositories.Auth;
using User.Infraestructure.Data;

namespace User.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;

        public UserRepository(AppDbContext _db) => db = _db;

        public async Task<bool> IsItBlockedAsync(LoginMO loginMo)
        {
           var blocked = await db.AppUsers.Where(x => x.Email == loginMo.Email).Select(x => x.Blocked).FirstOrDefaultAsync();

           return blocked;
        }

        public void BlockUser(LoginMO loginMo)
        {
            //Extraigo el usuario de la BD que estoy buscando segun el correo que
            //voy a bloquear
            var user = db.AppUsers.Where(x => x.Email == loginMo.Email).FirstOrDefault();
            //Actualizo la propiedad
            user.Blocked = true;

            //Actualizo el valor en la base de datos
            db.Update(user);

            db.SaveChanges();
        }

        public async Task<bool> ExistAsync(LoginMO loginMO)
        {
            return await db.AppUsers.AnyAsync(x => x.Email == loginMO.Email);
        }


    }
}
