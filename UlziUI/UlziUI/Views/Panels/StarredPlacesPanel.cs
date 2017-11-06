using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UlziUI.Classes.AppLanguages;
using UlziUI.Classes.Enums;
using UlziUI.Controls;
using UlziUI.Views.Pages;
using Xamarin.Forms;

namespace UlziUI.Views.Panels
{
	public class StarredPlacesPanel : Panel
	{
		private ScrollView _scroll = null;

		public StarredPlacesPanel() : base()
		{
		}

		protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			if ((propertyName == IsVisibleProperty.PropertyName) && (this.IsVisible))
				await this.ScrollToUp();
		}

		private async Task ScrollToUp()
		{
			if (_scroll != null)
				await Panel.DelayActionAsync(100, () => { _scroll.ScrollToAsync(0, 0, true); });
		}


		protected override View CreateContent()
		{
			this.BackgroundColor = Color.White;


			var navigationContentHeight = MainPage.PageHeight * 0.1;
			var mainLabelContentHeight = MainPage.PageHeight * 0.3;
			var placesContentHeight = MainPage.PageHeight * 0.38;
			var bottomMenuHeight = MainPage.PageHeight * 0.18;


			var navigationTopOffset = MainPage.PageHeight / 68.342;
			var navigationLabelFontSize = MainPage.PageHeight / 56.951;
			var arrowWidth = MainPage.PageHeight / 34.171;
			var arrowHeight = MainPage.PageHeight / 34.171;

			var plusWidth = MainPage.PageHeight / 34.171;
			var plusHeight = MainPage.PageHeight / 34.171;
			var navigationPadding = MainPage.PageHeight / 68.342;


			var mainLabelFontSize = MainPage.PageHeight / 45.561;
			var mainLabelTopOffset = MainPage.PageHeight / 68.342;
			var mainLabelPadding = MainPage.PageHeight / 34.171;


			var placesListLabelFontSize = MainPage.PageHeight / 45.561;
			var placesListTopOffset = MainPage.PageHeight / 34.171;

			var placesListImageHeight = MainPage.PageHeight / 45.561;
			var placesListImageWidth = MainPage.PageHeight / 45.561;
			var placesListFontSize = MainPage.PageHeight / 45.561;


			var bottomMenuIconHeight = MainPage.PageHeight * 0.13; 
			var bottomMenuIconWidth = MainPage.PageWidth * 0.25;
			var bottomMenuIconBottomOffset = MainPage.PageHeight / 136.684;

			var bottomMenuImageHeight =MainPage.PageHeight / 22.780;
			var bottomMenuImageWidth = MainPage.PageWidth * 0.10;
			var bottomMenuImageTopOffset = MainPage.PageHeight * 0.03;

           var bottomMenuContentTopOffset = - MainPage.PageHeight * 0.09;

            var bottomMenuBackgroundImageHeight = MainPage.PageHeight * 0.10;
            var bottomMenuBackgroundImageWidth = MainPage.PageWidth * 0.70;

         








			#region TopNavigationBar


			var arrow = new Image
			{
				WidthRequest = arrowWidth,
				HeightRequest = arrowHeight,
				Source = "back"
			};
			var arrowContent = new ContentView
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.End,

				//Padding = new Thickness(0, navigationTopOffset, 0, 0),
				Content = arrow
			};

			var navigationLabel = new AppLabel
			{

				AppFont = AppFonts.Quicksand,
				FontSize = navigationLabelFontSize,
				TextColor = Color.White,
				VerticalTextAlignment = TextAlignment.Center
			};
			navigationLabel.SetBinding(AppLabel.TextProperty, new Binding("StarredPlacesNavigationTitleText", BindingMode.OneWay, null, null, null, AppLanguages.CurrentLanguage));


			var navigationLabelContent = new ContentView
			{

				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.End,

				//Padding = new Thickness(0, navigationTopOffset, 0, 0),
				Content = navigationLabel
			};

			var plus = new Image
			{

				WidthRequest = plusWidth,
				HeightRequest = plusHeight,
				Source = "plus_gray"
			};

			var plusContent = new ContentView
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				//Padding = new Thickness(0, navigationTopOffset, 0, 0),
				Content = plus,
				VerticalOptions = LayoutOptions.End,

			};

			var navigationContent = new StackLayout
			{
				BackgroundColor = Color.FromHex("#1BA4A8"),
				HeightRequest = navigationContentHeight,
				Padding = new Thickness(0, 0, 0, navigationPadding),
				Orientation = StackOrientation.Horizontal,

				//Margin = new Thickness(0, 20, 0, 0),
				Children ={
					arrowContent,navigationLabelContent,plusContent
				}

			};


			#endregion

			#region MainText

			var mainLabel = new AppLabel
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				AppFont = AppFonts.Quicksand,
				FontSize = mainLabelFontSize,
				TextColor = Color.White
			};
			mainLabel.SetBinding(AppLabel.TextProperty, new Binding("StarredPlacesMainText", BindingMode.OneWay, null, null, null, AppLanguages.CurrentLanguage));


			var mainLabelContent = new StackLayout
			{

				BackgroundColor = Color.FromHex("#32848B"),
				HeightRequest = mainLabelContentHeight,

				Padding = new Thickness(mainLabelPadding, 0, mainLabelPadding, 0),
				Children ={
					mainLabel
				}

			};


			#endregion




			#region Places List

			var placeListLabel = new AppLabel
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				AppFont = AppFonts.Quicksand,
				FontSize = placesListLabelFontSize,

			};
			placeListLabel.SetBinding(AppLabel.TextProperty, new Binding("StarredPlacesListTitleText", BindingMode.OneWay, null, null, null, AppLanguages.CurrentLanguage));


			var placeListContent = new StackLayout
			{


				HeightRequest = 20,
				//Padding = new Thickness(10, 0, 0, 0),
				Children ={
					placeListLabel
				}

			};

			var schoolImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesListImageHeight,
				WidthRequest = placesListImageWidth,
			};

			var schoolLabel = new AppLabel
			{
				Text = "School",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesListFontSize,
			};

			var schoolContent = new StackLayout
			{

				Orientation = StackOrientation.Horizontal,
				Children ={
					schoolImage,schoolLabel
				}

			};

			var homeLabel = new AppLabel
			{

				Text = "Home",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesListFontSize,
			};

			var homeImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesListImageHeight,
				WidthRequest = placesListImageWidth,
			};

			var homeContent = new StackLayout
			{

				Orientation = StackOrientation.Horizontal,
				Children ={
					homeImage,homeLabel
				}
			};

			var workLabel = new AppLabel
			{

				Text = "Work",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesListFontSize,
			};

			var workImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesListImageHeight,
				WidthRequest = placesListImageWidth,

			};

			var workContent = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children ={
					workImage,workLabel
				}
			};




			var addStarredPlacesLabel = new AppLabel
			{

				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesListLabelFontSize,

				AppFont = AppFonts.Quicksand,


			};
			addStarredPlacesLabel.SetBinding(AppLabel.TextProperty, new Binding("AddStarredPlacesLabel", BindingMode.OneWay, null, null, null, AppLanguages.CurrentLanguage));



			var addStarredPlacesImage = new AppImage
			{
				Source = "plus_gray",
				HeightRequest = placesListImageHeight,
				WidthRequest = placesListImageWidth,
			};

			var addStarredPlacesContent = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children ={
					addStarredPlacesImage,addStarredPlacesLabel
				}
			};


			var placesWrapperContent = new StackLayout
			{
				BackgroundColor = Color.White,

				Children ={
					placeListContent,schoolContent,homeContent,workContent,addStarredPlacesContent
				}
			};

			var placesContent = new StackLayout
			{

				Padding = new Thickness(placesListTopOffset, placesListTopOffset, 0, 0),

				HeightRequest = placesContentHeight,
				Children ={
					placesWrapperContent
				}
			};


			#endregion




			#region  Bottom menu


            var icon = new AppImage
			{
				Source = "emergency",
				HeightRequest = bottomMenuIconHeight,
				WidthRequest = bottomMenuIconWidth,
               
			};

            var iconContent = new StackLayout
            {
                Padding = new Thickness(0,0,0,bottomMenuIconBottomOffset),
                HorizontalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				Children ={
					icon
				}
			};

			var group = new Image
			{
				Source = "profile_gray",
				HeightRequest = bottomMenuImageHeight,
				WidthRequest = bottomMenuImageWidth,
			};

			var groupContent = new StackLayout
			{

				VerticalOptions = LayoutOptions.EndAndExpand,
				Children ={
					group
				}
			};


			var location = new Image
			{
				Source = "home",
				HeightRequest = bottomMenuImageHeight,
				WidthRequest = bottomMenuImageWidth,
			};

			var locationContent = new StackLayout
			{

				VerticalOptions = LayoutOptions.EndAndExpand,
				Children ={
					location
				}
			};

			var notification = new Image
			{
                
				Source = "bell_gray",
				HeightRequest = bottomMenuImageHeight,
				WidthRequest = bottomMenuImageWidth,
			};

			var notificationContent = new StackLayout
			{

				VerticalOptions = LayoutOptions.EndAndExpand,
				Children ={
					notification
				}
			};

			var menuIcon = new Image
			{
				
				Source = "account_green",
				HeightRequest = bottomMenuImageHeight,

				WidthRequest = bottomMenuImageWidth,
			};

            var menuIconContent = new StackLayout
            {  
                VerticalOptions = LayoutOptions.EndAndExpand,
				Children ={
					menuIcon
				}
			};

            var menuBackground = new Image
            {
               Aspect = Aspect.Fill,
               
                HeightRequest = bottomMenuBackgroundImageHeight,
                Source="Menu_Background"
            };

            var menuBackgroundContent = new StackLayout
            {
				
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children ={
                    menuBackground
                }
            };

            var bottomMenuContent = new StackLayout
            {
                 
               
                Spacing = 40,
                Padding= new Thickness(0,0,10,10),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				HeightRequest = bottomMenuHeight,
				Children ={
					groupContent, locationContent, notificationContent,menuIconContent
				}
			};

			var menuContent = new Grid
			{
                HeightRequest=50,
                WidthRequest= 360,
               
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.End,
				RowSpacing = 0,
				ColumnSpacing = 0
			};
            menuContent.Children.Add(menuBackground);
            menuContent.Children.Add(bottomMenuContent);

			


            var menuContentFinal = new StackLayout{
                
             Spacing = -43,

                VerticalOptions = LayoutOptions.End,
             Orientation = StackOrientation.Horizontal,
                Children ={
                    iconContent,menuContent
                }
            };

			#endregion


			#region  Places



			var finalContent = new StackLayout
			{
               
                VerticalOptions = LayoutOptions.End,    
				Spacing = 0,
				Children ={
					navigationContent, mainLabelContent,placesContent, menuContentFinal
				}

			};


			#endregion



			_scroll = new ScrollView
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Content = finalContent
			};

			return _scroll;
		}
	}
}
