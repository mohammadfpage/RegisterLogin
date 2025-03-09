using UniProject.Models.BaseDto;
using UniProject.Models.Entity.Users;

namespace UniProject.Services.Login
{
    public interface ILoginService
    {
        public Task<ValueDto<UserLoginDto>> Execute(UserLoginDto user);
    }
}
