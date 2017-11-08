
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

			this.LeftEntryCommand = new VisualCommand(this.LeftEntyTap);
			this.RightEntryCommand = new VisualCommand(this.RightEntryTap);

			this.AddPeopleCommand = new VisualCommand(this.AddPeople);
			this.CurrentLocationCommand = new VisualCommand(this.CurrentLocation);
			this.MoreStarredPlacesCommand = new VisualCommand(this.MorePreviousSearches);

			this.EnableCommands();


		}




		private void DisableCommands()
		{
			this.LeftEntryCommand.IsEnabled = false;
			this.RightEntryCommand.IsEnabled = false;
			this.MoreStarredPlacesCommand.IsEnabled = false;
			this.AddPeopleCommand.IsEnabled = false;

		}

		private void EnableCommands()
		{
			this.LeftEntryCommand.IsEnabled = true;
			this.RightEntryCommand.IsEnabled = true;
			this.MoreStarredPlacesCommand.IsEnabled = true;
			this.AddPeopleCommand.IsEnabled = true;

		}


		private void MoreStarredPlaces(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);
		}



		private void LeftEntyTap(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);
		}

		private void RightEntryTap(object parameter)
		{

		}

		private void AddPeople(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);

		}

		private void CurrentLocation(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);

		}

		private void MorePreviousSearches(object parameter)
		{
			this.MainViewModel.PushPanel(AppConstants.APP_PANEL_STARRED);
		}



		public VisualCommand LeftEntryCommand { get; private set; }

		public VisualCommand RightEntryCommand { get; private set; }

		public VisualCommand MoreStarredPlacesCommand { get; private set; }

		public VisualCommand AddPeopleCommand { get; private set; }

		public VisualCommand CurrentLocationCommand { get; private set; }

		public VisualCommand MorePreviousSearchesCommand { get; private set; }



	}
}
