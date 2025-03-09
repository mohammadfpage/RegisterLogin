using System.Threading.Tasks;
using UniProject.Models.BaseDto;
using UniProject.Models.Entity.Users;

namespace UniProject.Services.Register
{
    public interface IRegisterService
    {
        public Task<ValueDto<User>> Execute(User user);
    }
}
