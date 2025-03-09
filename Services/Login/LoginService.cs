using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UniProject.Migrations.Context;
using UniProject.Models.BaseDto;
using UniProject.Models.Entity.Users;

namespace UniProject.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ValueDto<UserLoginDto>> Execute(UserLoginDto user)
        {
            if (user == null)
            {
                return new ValueDto<UserLoginDto>
                {
                    value = user,
                    Message = "لطفا اطلاعات خواسته شده را به درستی وارد کنید",
                    result = false,
                };
            }
            var result = await _context.Users.Where(item => item.Email == user.Email && item.Password == user.Password).FirstOrDefaultAsync();

            if (result == null)
            {
                return new ValueDto<UserLoginDto>
                {
                    value = user,
                    Message = "لطفا ثبت نام کنید و سپس وارد سایت شوید",
                    result = false,
                };
            }

            return new ValueDto<UserLoginDto>
            {
                value = user,
                Message = "ایمیل و پسورد شما درست است",
                result = true,
            };
        }
    }
}
