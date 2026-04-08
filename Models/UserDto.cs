using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名是必填项")]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        public string Email { get; set; } = string.Empty;
    }
}