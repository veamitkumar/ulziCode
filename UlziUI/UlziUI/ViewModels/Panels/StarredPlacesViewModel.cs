using System;
using UlziUI.Classes;
using UlziUI.ViewModels.Pages;
namespace UlziUI.ViewModels.Panels
{
	public class StarredPlacesViewModel : PanelViewModel
	{
		public StarredPlacesViewModel(MainViewModel mainViewModel) : base(mainViewModel)
		{

			this.BackCommand = new VisualCommand(this.Back);

			this.plusCommand = new VisualCommand(this.plus);
			this.AddStarredPlacesCommand = new VisualCommand(this.AddStarredPlaces);

			this.profileCommand = new VisualCommand(this.profile);
			this.locationCommand = new VisualCommand(this.location);
			this.notificationCommand = new VisualCommand(this.notification);
			this.menuCommand = new VisualCommand(this.menu);


			this.EnableCommands();

		}


		private void DisableCommands()
		{
			this.BackCommand.IsEnabled = false;
			this.plusCommand.IsEnabled = false;
			this.AddStarredPlacesCommand.IsEnabled = false;


		}

		private void EnableCommands()
		{
			this.BackCommand.IsEnabled = true;
			this.plusCommand.IsEnabled = true;
			this.AddStarredPlacesCommand.IsEnabled = true;


		}




		private void Back(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}



		private void plus(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}

		private void AddStarredPlaces(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}

		private void profile(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}

		private void location(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}

		private void notification(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}

		private void menu(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_HOME);
		}




		public VisualCommand BackCommand { get; private set; }

		public VisualCommand plusCommand { get; private set; }

		public VisualCommand AddStarredPlacesCommand { get; private set; }

		public VisualCommand profileCommand { get; private set; }

		public VisualCommand locationCommand { get; private set; }
		public VisualCommand notificationCommand { get; private set; }
		public VisualCommand menuCommand { get; private set; }



	}
}
