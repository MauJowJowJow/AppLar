using AppLar.Core.Data;
using AppLar.Core.Page;
using AppLar.Core.ViewModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.IO;
using Xamarin.Forms;

namespace AppLar.Core
{
    public class App 
        //: MvxApplication
        : Application
    {
        public App()
        {
            /*
            // set up the model
            Mvx.RegisterSingleton<IMedicamentoDAO>(() => new MedicamentoDAO());

            // set the start object
            RegisterAppStart<MedicamentoViewModel>();
            */

            MainPage = new MedicamentoPage();
        }
    }
}
