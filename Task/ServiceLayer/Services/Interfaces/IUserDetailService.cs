using ServiceLayer.DTOs.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IUserDetailService
    {
        UserDetailDto GetUserInfo();
        UserIdDto GetUserId();
    }
}
