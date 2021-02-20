using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using Microsoft.Extensions.Options;

namespace CleanArch.RazorPage.Pages.CourseDetails
{
    //[Breadcrumb("ذخیره دروس ")]
    public class SaveCourseModel : PageModel
    {
        [BindProperty]
        public CleanArch.Domain.Models.Course CourseModel { get; set; }
        public IEnumerable<CourseType> courseType { get; set; }
        public SelectList coursetypelist { get; set; }

        private ICourseService _courseService;
        private ICourseTypeService _courseTypeService;

        private IValidator<Course> _courseValidator;
        //  public LanguageSchoolDbContext _ctx;


        public SaveCourseModel(ICourseService courseService, ICourseTypeService courseTypeService,
            IValidator<Course> coursevalidation)//, LanguageSchoolDbContext ctx)
        {
            _courseService = courseService;
            _courseTypeService = courseTypeService;
            _courseValidator = coursevalidation;

            // _ctx = ctx;
        }

        public IActionResult OnGet(int? id)
        {
            //bind dropdownlist
            BindDropDownLists();
            //
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
            var UploadedFileSize = Request.ContentLength;

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
            catch (Exception ex)
            {
                throw ex;
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
        public void BindDropDownLists()
        {
            //// بایند کردن لیست دروس
            courseType = _courseTypeService.GetCourseTypesAsync().Result;
            coursetypelist = new SelectList(courseType, nameof(CourseType.Id), nameof(CourseType.Title));
        }
    }
}