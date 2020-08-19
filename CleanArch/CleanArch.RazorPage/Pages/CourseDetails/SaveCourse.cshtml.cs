using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;

namespace CleanArch.RazorPage.Pages.CourseDetails
{
    //[Breadcrumb("ذخیره دروس ")]
    public class SaveCourseModel : PageModel
    {
        [BindProperty]
        public CleanArch.Domain.Models.Course CourseModel { get; set; }

        private ICourseService _courseService;

        private IValidator<Course> _courseValidator;

        public SaveCourseModel(ICourseService courseService, IValidator<Course> coursevalidation)
        {
            _courseService = courseService;
            _courseValidator = coursevalidation;


        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                //Parent="خانه"
                var breadcrumbNode = new RazorPageBreadcrumbNode("/CourseDetails/SaveCourse", "ذخیره دروس");                
                ViewData["BreadcrumbNode"] = breadcrumbNode;
                return Page();
            }

            var breadcrumbNode1 = new RazorPageBreadcrumbNode("/CourseDetails/SaveCourse", "ذخیره دروس")
            {
                OverwriteTitleOnExactMatch = true,
                Parent = new RazorPageBreadcrumbNode("/CourseDetails/ShowCourses", "مشاهده دروس")

            };

            ViewData["BreadcrumbNode"] = breadcrumbNode1;
            CourseModel = _courseService.GetCourseById((int)id);

            if (CourseModel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? Id)//string Id:value of hidden field
        {
            var res = _courseValidator.Validate(CourseModel);

            if (!res.IsValid)
            {
                return Page();
            }

            try
            {
                if (Id == 0 || Id == null)
                {
                    _courseService.Add(CourseModel);
                     ModelState.Clear();
                    return RedirectToPage("./SaveCourse");
                }
                else
                {
                    _courseService.Update(CourseModel);
                    return RedirectToPage("./ShowCourses");
                }
            }
            catch
            {
                throw;
            }


        }

        public ActionResult OnPostNew()
        {
            ModelState.Clear();
            return RedirectToPage("./SaveCourse");
        }

        public ActionResult OnPostReturn()
        {
            ModelState.Clear();
            return RedirectToPage("./ShowCourses");
        }
    }
}