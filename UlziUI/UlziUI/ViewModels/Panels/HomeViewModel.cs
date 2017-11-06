
using System;
using System.Collections.Generic;
using System.Text;
using UlziUI.Classes;
using UlziUI.Classes.AppLanguages;
using UlziUI.ViewModels.Pages;
namespace UlziUI.ViewModels.Panels
{
	public class HomeViewModel : PanelViewModel
	{
		public HomeViewModel(MainViewModel mainViewModel) : base(mainViewModel)
		{
            this.MoreStarredPlacesCommand = new VisualCommand(this.MoreStarredPlaces);

			
		}

		private void MoreStarredPlaces(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);
		}


		public VisualCommand MoreStarredPlacesCommand { get; private set; }

      
	}
}
