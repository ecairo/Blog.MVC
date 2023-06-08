using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class WizardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Wizard
        public ActionResult Step1()
        {
            var step1ViewModel = new ViewModels.WizardViewModels.WizardViewModel()
            {
                Step1 = new ViewModels.WizardViewModels.Step1ViewModel(),
                WizardStepState = ViewModels.WizardViewModels.WizardStep.STEP1
            };

            return View(step1ViewModel);
        }

        [HttpPost]
        public ActionResult Step2(ViewModels.WizardViewModels.WizardViewModel wizardViewModel)
        {
            if (ModelState.IsValid)
            {
                Session["Step1"] = wizardViewModel.Step1;

                wizardViewModel.Step2 = new ViewModels.WizardViewModels.Step2ViewModel();

                wizardViewModel.WizardStepState = ViewModels.WizardViewModels.WizardStep.STEP2;

                return View("Step2", wizardViewModel);
            }

            return View("Step1", wizardViewModel);
        }

        [HttpPost]
        public ActionResult Step3(ViewModels.WizardViewModels.WizardViewModel wizardViewModel)
        {
            if (ModelState.IsValid)
            {
                Session["Step2"] = wizardViewModel.Step2;

                wizardViewModel.Step3 = new ViewModels.WizardViewModels.Step3ViewModel();

                wizardViewModel.WizardStepState = ViewModels.WizardViewModels.WizardStep.STEP3;

                return View("Step3", wizardViewModel);
            }

            return View("Step2", wizardViewModel);
        }

        [HttpPost]
        public ActionResult Finish(ViewModels.WizardViewModels.WizardViewModel wizardViewModel)
        {
            if (ModelState.IsValid)
            {
                Session["Step3"] = wizardViewModel.Step3;

                var step1Data = (ViewModels.WizardViewModels.Step1ViewModel)Session["Step1"];
                var step2Data = (ViewModels.WizardViewModels.Step2ViewModel)Session["Step2"];
                var step3Data = wizardViewModel.Step3;

                Session.Remove("Step1");
                Session.Remove("Step2");
                Session.Remove("Step3");

                return RedirectToAction("Index");
            }

            return View("Step3", wizardViewModel);
        }
    }
}