using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Repository
{
    public class ReDiaChi : IDiaChi
    {
        public readonly DoanContext _context;
        public ReDiaChi(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Diachi diachi)
        {
            _context.Add(diachi);
            return Save();
        }

        public bool Delete(Diachi diachi)
        {
            _context.Remove(diachi);
            return Save();
        }

        public Task<Diachi> GetGioHangById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Diachi diachi)
        {
            _context.Update(diachi);
            return Save();
        }
    }
}
