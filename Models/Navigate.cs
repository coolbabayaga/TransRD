using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransRD.Views;

namespace TransRD.Models
{
    public class Navigate
    {
        public async static void NavigateToPage(Page pageType, bool Comeback)
        {
            await Application.Current.MainPage.Navigation.PushAsync(pageType);

            if (!Comeback)
            {
                // Elimina la página anterior (LoginPage) para que no puedan volver
                var navStack = Application.Current.MainPage.Navigation.NavigationStack;
                if (navStack.Count > 1)
                {
                    Application.Current.MainPage.Navigation.RemovePage(navStack[navStack.Count - 2]);
                }
            }
        }
  }

    
}
