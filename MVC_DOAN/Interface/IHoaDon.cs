using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
	public interface IHoaDon
	{
		Task<IEnumerable<HoaDonVM>> GetAll();
		bool UpdateTTHD(EditTinhTrangHoaDonVM ehdvm);
		bool Add(Donhang donhang);
		bool Update(Donhang donhang);
		bool Delete(Donhang donhang);
		bool Save();
	}
}
