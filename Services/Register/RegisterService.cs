using Microsoft.EntityFrameworkCore;
using UniProject.Migrations.Context;
using UniProject.Models.BaseDto;
using UniProject.Models.Entity.Users;

namespace UniProject.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly AppDbContext _context;
        public RegisterService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ValueDto<User>> Execute(User user)
        {
            if (user != null)
            {
                var result = await _context.Users.Where(item => item.Email == user.Email || item.NationalCode == user.NationalCode).FirstOrDefaultAsync();
                if (result != null)
                {
                    return new ValueDto<User>
                    {
                        Message = "شما قبلا ثبت نام کرده اید لطفا وارد سایت شود.",
                        result = false,
                        value = result,
                    };
                }
            }
            user.CreateDate = DateTime.Now;
            user.UpdateTime = DateTime.Now;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new ValueDto<User> { Message = "با موفقیت ثبت نام کردید.", result = true, value = user };
        }
    }
}
