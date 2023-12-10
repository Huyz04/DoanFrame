using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Repository
{
    public class ReUser : IUser
    {
        private readonly DoanContext _context;

        public ReUser(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Taikhoan taikhoan)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Taikhoan taikhoan)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Taikhoan>> GetAllTaikhoan()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Taikhoan> GetTaikhoanbyId(string Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Taikhoan taikhoan)
        {
            _context.Update(taikhoan);
            return Save();
        }
    }
}
