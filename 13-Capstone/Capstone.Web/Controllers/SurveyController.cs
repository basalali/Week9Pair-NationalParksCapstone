using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDao surveyDao;
        //Inject controller
        public SurveyController(ISurveyDao surveyDao)
        {

            this.surveyDao = surveyDao;
        }


        public IActionResult Index()
        {
            IList<Survey> survey = surveyDao.GetTopSurveys();
            return View(survey);
        }

        [HttpGet]
        public IActionResult SaveNewSurvey()
        {
            Survey survey = new Survey();
            return View(survey);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNewSurvey(Survey post)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveNewSurvey", post);

            }
            surveyDao.SaveNewSurvey(post);

            return RedirectToAction("Index");
        }



    }
}


