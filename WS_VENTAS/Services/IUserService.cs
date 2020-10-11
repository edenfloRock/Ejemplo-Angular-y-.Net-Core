using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VENTAS.Models.Request;
using WS_VENTAS.Models.Response;

namespace WS_VENTAS.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);

    }
}
