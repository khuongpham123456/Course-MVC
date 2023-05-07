using VNR_InternShip.Entities;

namespace VNR_InternShip.Services
{
    public interface ICourse
    {
        public Task<IEnumerable<KhoaHoc>> getAllCourses();
        public Task<KhoaHoc> getCourseById(int id);
    }
}
