using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels.WizardViewModels
{
    public class WizardViewModel
    {
        public Step1ViewModel Step1 { get; set; }

        public Step2ViewModel Step2 { get; set; }

        public Step3ViewModel Step3 { get; set; }

        public WizardStep WizardStepState { get; set; }
    }

    public enum WizardStep
    {
        STEP1,
        STEP2,
        STEP3,
    }
}