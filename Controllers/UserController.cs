using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserDto> Users = new List<UserDto>();

        [HttpGet] // 查询
        public ActionResult<IEnumerable<UserDto>> GetUsers() => Ok(Users);

        [HttpPost] // 创建 (会自动触发数据验证)
        public IActionResult CreateUser(UserDto user)
        {
            Users.Add(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPut("{id}")] // 更新
        public IActionResult UpdateUser(int id, UserDto user)
        {
            var existingUser = Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) return NotFound();
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            return NoContent();
        }

        [HttpDelete("{id}")] // 删除
        public IActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            Users.Remove(user);
            return NoContent();
        }
    }
}