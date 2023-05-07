using VNR_InternShip.Entities;

namespace VNR_InternShip.Services
{
    public interface ISubject
    {
        public Task<IEnumerable<MonHoc>> getSubjectsByCourseId(int courseId);
    }
}
