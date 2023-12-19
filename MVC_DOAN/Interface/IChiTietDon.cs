using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface IChiTietDon
    {
        bool Add(CreateCTD crCTD);
        bool Update(Chitietdon ctd);
        bool Delete(Chitietdon ctd);
        bool Save();
    }
}
