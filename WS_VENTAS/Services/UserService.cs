using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VENTAS.Models;
using WS_VENTAS.Models.Request;
using WS_VENTAS.Models.Response;
using WS_VENTAS.Tools;

namespace WS_VENTAS.Services
{
    public class UserService : IUserService
    {
        
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse UsrResp = new UserResponse();
            using (var db= new MVC_SEGURIDADContext()) {
                string spwd = Encript.GetSHA256(model.password);
                var usuario = db.Usuarios.Where(d => d.Email == model.Email &&
                                    d.Pwd == spwd).FirstOrDefault();

                if (usuario != null)
                    UsrResp.Email = usuario.Email;
                
            }
            return UsrResp;
        }
    }
}
