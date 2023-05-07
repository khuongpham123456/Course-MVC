using Microsoft.EntityFrameworkCore;
using VNR_InternShip.Entities;

namespace VNR_InternShip.Services.ServicesImp
{
    public class SubjectImp : ISubject
    {
        private readonly VNR_InternShipContext _context;
        public SubjectImp(VNR_InternShipContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MonHoc>> getSubjectsByCourseId(int courseId)
        {
            try
            {
                return await _context.MonHocs.Where(x => x.KhoaHocId == courseId).ToListAsync();
            }catch(Exception ex) 
            { 
                Console.WriteLine(ex.ToString());    
            }
            return null;
        }
    }
}
