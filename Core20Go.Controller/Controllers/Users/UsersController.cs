using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core20Go.Repository;
using Core20Go.DTO;
using Core20Go.Entity;

namespace Core20Go.Controller.Controllers.Users
{
    [Route("apis/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private Repository.RepositoryInterface.IDataRepository _dataRepository;
        private string _connectionName = "DB_CORE_20_GO";

        public UsersController(Repository.RepositoryInterface.IRepositoryUserBasic dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        [HttpPost]
        public IActionResult doAction(Core20Go.DTO.Users.DTI_UserBasic dTI_UserBasic)
        {
            if (dTI_UserBasic == null)
                throw new ArgumentNullException();
            var entity = new Entity.Core_20_Go.User_Basic.Entity_User_Basic();
            entity.ConnectionName = _connectionName;
            entity.uid = Guid.NewGuid().ToString();
            entity.uname = dTI_UserBasic.uname;
            entity.pwd = dTI_UserBasic.pwd;
            entity.status = "1";
            int rows = ((Repository_UserBasic)_dataRepository).NewUser(entity);
            return Ok(rows);
        }

    }
}