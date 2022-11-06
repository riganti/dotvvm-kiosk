using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace Demo01_Basics.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }

        public void Calculate()
        {
            Result = Number1 + Number2;
        }
    }
}
