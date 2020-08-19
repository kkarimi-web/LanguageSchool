using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace CleanArch.RazorPage.Pages.CourseDetails
{
    [Breadcrumb("مشاهده دروس", FromPage = typeof(IndexModel))]
    public class ShowCoursesModel : PageModel
    {
        private ICourseService _courseService;

        public PaginatedList<Course> courses { get; set; }

        [BindProperty(SupportsGet = true)]
        public int pageIndex { get; set; } = 1;

        public ShowCoursesModel(ICourseService courseService)
        {
            _courseService = courseService;
        }


        public async Task OnGetAsync(int? pageIndex)
        {
            CourseViewModel t = _courseService.GetCourses();
            courses = await PaginatedList<Course>.CreateAsync(
                     t.Courses.AsQueryable(), pageIndex ?? 1, 10);
        }

        public IActionResult OnPostDelete(int Id)
        {
            _courseService.Delete(Id);
            return RedirectToPage("./ShowCourses");
        }
    }
}