using Microsoft.EntityFrameworkCore;
using VNR_InternShip.Entities;

namespace VNR_InternShip.Services.ServicesImp
{
    public class CourseImp : ICourse
    {
        private readonly VNR_InternShipContext _context;
        public CourseImp(VNR_InternShipContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<KhoaHoc>> getAllCourses()
        {
            try
            {
                return await _context.KhoaHocs.ToListAsync();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public async Task<KhoaHoc> getCourseById(int id)
        {
            try
            {
                return await _context.KhoaHocs.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
