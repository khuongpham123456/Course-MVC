using Microsoft.AspNetCore.Mvc;
using VNR_InternShip.Entities;
using VNR_InternShip.Services;

namespace VNR_InternShip.Controllers
{
    public class CourseController : Controller
    {
        private ICourse _iCourse;
        private ISubject _iSubject;
        public CourseController(ICourse iCourse, ISubject iSubject)
        {
            _iCourse = iCourse;
            _iSubject = iSubject;
        }
        public async Task<IActionResult> Index(int id)
        {
            if (id != 0)
            {
                IEnumerable<MonHoc> subjects = await _iSubject.getSubjectsByCourseId(id);
                KhoaHoc course = await _iCourse.getCourseById(id);
                ViewBag.Subjects = subjects;
                ViewBag.Course = course;
            }
            IEnumerable<KhoaHoc> courses = await _iCourse.getAllCourses();
            ViewBag.Courses = courses;
            return View();
        }
    }
}
