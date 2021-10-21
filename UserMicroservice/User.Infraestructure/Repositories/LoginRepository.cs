using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Auth.Login;
using User.Infraestructure.Data;
using User.Infraestructure.Repositories;
using User.Domain.Repositories.Auth;
using User.Infraestructure.Data.DbModels;

namespace User.Infraestructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext db;

        //Se obtienen una instancia de AppDbContextmediante inyecciones de dependencias
        public LoginRepository(AppDbContext _db) => db = _db;
        enum isItOk
        {
            Ok = 1,
            Failed = -1
        }

        public LoginResultMO SignIn(LoginMO loginDto)
        {

            

            //Se devuelve el usuario que coincida con las credenciales de loginDto y se guarda en result
            var result = db.AppUsers.Where(x => x.Email == loginDto.Email && x.Password == loginDto.Password)
                .Select(x => new { Id = x.Id, Blocked = x.Blocked }).FirstOrDefault();

            if(result != null)
            {
                    LoginResultMO loginRes = new LoginResultMO()
                    {
                        ResultLogin = (int)isItOk.Ok,
                        UserId = result.Id,
                    };
                    return loginRes;
       
            }
            

            LoginResultMO loginRe = new LoginResultMO()
            {
                ResultLogin = (int)isItOk.Failed
            };

            return loginRe;

        }

        public LoginFailResultMO AddFail(LoginMO failLogin)
        {
            

            var failFound = db.FailUserLogin.Where(x => x.appUserEmail == failLogin.Email).FirstOrDefault();
            
            LoginFailResultMO loginFailResult = new LoginFailResultMO();


            if (failFound != null)
            {
                failFound.Time++;
                if (failFound.Time != 3)
                {
                    
                    db.Update(failFound);
                    db.SaveChanges();
                    loginFailResult.Blocked = false;
                }
                else
                {
                    loginFailResult.Blocked = true;
                }
            }
            else
            {
                FailUserLogin entity = new FailUserLogin()
                {
                    appUserEmail = failLogin.Email,
                    Time = 1
                };

                db.FailUserLogin.Add(entity);
                db.SaveChanges();
                loginFailResult.Blocked = false;
            }

            
            return loginFailResult;
        }


    }
}
