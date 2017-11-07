
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using mcpNetwork.Components.Forms;
using UlziUI.Classes.AppLanguages;
using UlziUI.Classes.Enums;
using UlziUI.Controls;
using UlziUI.Views.Pages;
using Xamarin.Forms;

namespace UlziUI.Views.Panels
{
	public class HomePanel : Panel
	{
		StackLayout searchPeopleContent;
		StackLayout peopleListContent;
		StackLayout currentLocationContent;
		StackLayout placesContent;
		StackLayout searchContent;
		StackLayout finalContent;
		StackLayout placesWrapperContent;


		StackLayout schoolContent;
		AppLabel schoolLabel;
		AppImage schoolImage;

		StackLayout homeContent;
		AppLabel homeLabel;
		AppImage homeImage;

		StackLayout workContent;
		AppLabel workLabel;
		AppImage workImage;


		StackLayout moreStarredPlacesContent;
		AppCommand moreStarredPlacesLabel;
		AppImage moreStarredPlacesImage;

		AppLabel currentLocationLabel;
		AppImage currentLocationImage;
		StackLayout currentLocationContentDetails;

		ListView searchListView;

		AppImage morePreviousSerchesImage;
		AppLabel morePreviousSearchesLabel;
		StackLayout morePreviousSearchesContent;




		private ScrollView _scroll = null;

		public HomePanel() : base()
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


			var searchBarHeight = MainPage.PageHeight * 0.07;
			var peopleListHeight = MainPage.PageHeight * 0.15;
			var currentLocationHeight = MainPage.PageHeight * 0.06;
			var placesHeight = MainPage.PageHeight * 0.20;
			var morePlacesHeight = MainPage.PageHeight * 0.34;



			var searchImageSize = MainPage.PageHeight / 25.001;
			var searchContentleftOffset = MainPage.PageHeight / 68.342;
			var searchContenttopOffset = MainPage.PageHeight / 17.855;

			var addPeopleLabelFontSize = MainPage.PageHeight / 60.6364;
			var addPeopleImageWidthHeight = MainPage.PageHeight / 18.5;
			var addPeopleConytentWidth = MainPage.PageHeight / 6.8342;
			// var peopleListHeight = 130;

			var currentLocationImageWidthHeight = MainPage.PageHeight / 30.171;
			var currentLocationLabelSize = MainPage.PageHeight / 45.636;
			var currentLocationContentDetailLeftOffset = MainPage.PageHeight / 38.342;
			var currentLocationContentLeftRightOffset = MainPage.PageHeight / 68.342;

			var placesLabelFontSize = MainPage.PageHeight / 45.636;
			var placesImageWidth = MainPage.PageHeight / 30.171;
			var placesImageHeight = MainPage.PageHeight / 30.171;
			var placesOffset = MainPage.PageHeight / 38.342;

			var placesContentOffset = MainPage.PageHeight / 68.342;

			var searchImageWidth = MainPage.PageHeight / 30.171;
			var searchImageHeight = MainPage.PageHeight / 30.171;
			var searchOffset = MainPage.PageHeight / 68.342;

			var morePlacesSearchOffset = MainPage.PageHeight / 32.345;


			#region Page Background
			this.BackgroundColor = Color.LightGray;
			this.Opacity = 1.0;


			#endregion


			#region Сontent

			#region SearchBar

			var searchEntry = new AppSearchEntryEditor
			{
				ImageSize = searchImageSize,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Search People and Places",
				WidthRequest = 280,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};


			searchPeopleContent = new StackLayout
			{
				Margin = new Thickness(searchContentleftOffset, searchContenttopOffset, 10, 0),
				BackgroundColor = Color.White,
				HeightRequest = searchBarHeight,
				Children ={
					searchEntry
				}

			};


			#endregion




			#region People List
			var addPeopleLabel = new AppLabel
			{
				FontSize = addPeopleLabelFontSize,
				Text = "Add People",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.End,

			};

			var addPeopleImage = new AppImage
			{
				Source = "plus_gray",
				WidthRequest = addPeopleImageWidthHeight,
				HeightRequest = addPeopleImageWidthHeight,

			};



			var addPeopleContent = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				WidthRequest = addPeopleConytentWidth,
				Children ={
					addPeopleImage,addPeopleLabel
				}

			};

			var dataHScroll2 = new HScrollViewCell2Data[] {
				new HScrollViewCell2Data { name = "jamie luna",  profileImage ="default_user", strokeColor=Color.Red},
				new HScrollViewCell2Data { name = "barde luna",  profileImage ="default_user", strokeColor=Color.Yellow},
				new HScrollViewCell2Data { name = "gerald luna",  profileImage ="default_user"},
				new HScrollViewCell2Data {name = "jamie luna",  profileImage ="default_user"},
				new HScrollViewCell2Data { name = "gerald luna",  profileImage ="default_user"},
				new HScrollViewCell2Data { name = "barde luna",  profileImage ="default_user"},

			};



			HorizontalScrollLayout peopleList = new HorizontalScrollLayout
			{
				ItemSource = dataHScroll2,
				ItemTemplate = new DataTemplate(typeof(HScrollViewCell2)),
				HeightRequest = 130,
				//WidthRequest = 170,
				SelectionBackGroundColor = Color.FromHex("#0040FF"),
				MultiSelection = false,

			};




			peopleListContent = new StackLayout
			{

				BackgroundColor = Color.White,
				HeightRequest = peopleListHeight,
				Orientation = StackOrientation.Horizontal,
				Children ={
					addPeopleContent, peopleList
				}
			};



			#endregion


			#region CurrentLocation


			currentLocationImage = new AppImage
			{
				Source = "map_gray",
				HeightRequest = currentLocationImageWidthHeight,
				WidthRequest = currentLocationImageWidthHeight,
			};

			currentLocationLabel = new AppLabel
			{
				Text = "Current Location",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = currentLocationLabelSize,
			};

			currentLocationContentDetails = new StackLayout
			{

				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = new Thickness(currentLocationContentDetailLeftOffset, 0, 0, 0),
				Children ={
					currentLocationImage,currentLocationLabel
				}

			};


			currentLocationContent = new StackLayout
			{
				Margin = new Thickness(currentLocationContentLeftRightOffset, 0, currentLocationContentLeftRightOffset, 0),
				BackgroundColor = Color.White,
				HeightRequest = currentLocationHeight,
				Children ={
					currentLocationContentDetails
				}
			};

			#endregion

			#region  Places

			schoolImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesImageHeight,
				WidthRequest = placesImageHeight,
			};

			schoolLabel = new AppLabel
			{
				Text = "School",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesLabelFontSize,
			};

			schoolContent = new StackLayout
			{

				Orientation = StackOrientation.Horizontal,
				Children ={
					schoolImage,schoolLabel
				}

			};

			homeLabel = new AppLabel
			{

				Text = "Home",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesLabelFontSize,
			};

			homeImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesImageHeight,
				WidthRequest = placesImageWidth,
			};

			homeContent = new StackLayout
			{

				Orientation = StackOrientation.Horizontal,
				Children ={
					homeImage,homeLabel
				}
			};

			workLabel = new AppLabel
			{

				Text = "Work",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = placesLabelFontSize,
			};

			workImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesImageHeight,
				WidthRequest = placesImageWidth,

			};

			workContent = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children ={
					workImage,workLabel
				}
			};


			moreStarredPlacesLabel = new AppCommand
			{



				FontSize = placesLabelFontSize,
			};

			moreStarredPlacesLabel.SetBinding(AppCommand.TextProperty, new Binding("MoreStarredPlaces", BindingMode.OneWay, null, null, null, AppLanguages.CurrentLanguage));

			moreStarredPlacesLabel.SetBinding(AppCommand.CommandProperty, "MoreStarredPlacesCommand");



			moreStarredPlacesImage = new AppImage
			{
				Source = "star_gray",
				HeightRequest = placesImageHeight,
				WidthRequest = placesImageWidth,
			};

			moreStarredPlacesContent = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children ={
					moreStarredPlacesImage,moreStarredPlacesLabel
				}
			};


			placesWrapperContent = new StackLayout
			{

				Padding = new Thickness(placesOffset, placesContentOffset, 0, 0),
				Children ={
					schoolContent,homeContent,workContent,moreStarredPlacesContent
				}
			};

			placesContent = new StackLayout
			{
				Margin = new Thickness(placesContentOffset, 0, placesContentOffset, 0),
				BackgroundColor = Color.White,
				HeightRequest = placesHeight,
				Children ={
					placesWrapperContent
				}
			};

			#endregion


			#region Search




			searchListView = new ListView
			{
				Margin = new Thickness(searchOffset, 0, searchOffset, 0),
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(SearchesTemplate)),
				ItemsSource = SearchData.GetData(),
				SeparatorColor = Color.White,


			};

			searchListView.HasUnevenRows = true;



			morePreviousSerchesImage = new AppImage
			{
				Source = "clock_gray",
				WidthRequest = searchImageWidth,
				HeightRequest = searchImageHeight,
			};

			morePreviousSearchesLabel = new AppLabel
			{
				Text = "More Previous Searches"
			};

			morePreviousSearchesContent = new StackLayout
			{
				Padding = new Thickness(morePlacesSearchOffset, 0, 0, searchOffset),
				Orientation = StackOrientation.Horizontal,
				Children ={
					morePreviousSerchesImage,morePreviousSearchesLabel
				}
			};



			searchContent = new StackLayout
			{
				Margin = new Thickness(searchOffset, 0, searchOffset, 0),
				BackgroundColor = Color.White,
				HeightRequest = morePlacesHeight,
				Children ={
					searchListView, morePreviousSearchesContent
				}
			};



			#endregion

			finalContent = new StackLayout
			{
				Spacing = searchOffset,

				Children ={
					searchPeopleContent, peopleListContent,currentLocationContent,placesContent,searchContent
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

	public class SearchesTemplate : ViewCell
	{
		AppImage searchImage;
		AppLabel searchLabelHeading;
		AppLabel searchLabelDetail;

		StackLayout searchDetailContent;
		StackLayout searchImageContent;
		StackLayout searchFinalContent;



		public SearchesTemplate()
		{
			var searchImageWidth = 20;
			var searchImageHeight = 20;

			var searchLabelHeadingSize = MainPage.PageHeight / 45.636;

			var searchLabelDetailSize = MainPage.PageHeight / 60.636;
			var searchOffset = 5;

			searchImage = new AppImage
			{
				WidthRequest = searchImageWidth,
				HeightRequest = searchImageHeight,
				Source = "clock_gray",
			};

			searchLabelHeading = new AppLabel
			{
				FontSize = searchLabelHeadingSize,

			};

			searchLabelHeading.SetBinding(AppLabel.TextProperty, "searchHeading");

			searchLabelDetail = new AppLabel
			{
				FontSize = searchLabelDetailSize,
				Opacity = 0.5,
			};

			searchLabelDetail.SetBinding(AppLabel.TextProperty, "searchDetail");

			searchDetailContent = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Spacing = 0,
				Children ={
					searchLabelHeading,searchLabelDetail
				}
			};

			var searchLeftOffset = MainPage.PageHeight / 67.342;


			searchFinalContent = new StackLayout
			{
				Padding = new Thickness(searchLeftOffset, searchOffset, 0, 0),
				Orientation = StackOrientation.Horizontal,
				Children ={
					searchImage,searchDetailContent
				}
			};

			View = searchFinalContent;

		}

	}



	public class SearchDetails
	{
		public string searchHeading { get; set; }
		public string searchDetail { get; set; }

	}

	public static class SearchData
	{
		public static List<SearchDetails> GetData()
		{
			return new List<SearchDetails> {
				new SearchDetails () {
					searchHeading="872 higuera ST.",
					searchDetail="San Luis Obispo CA 93401",
				},
				new SearchDetails () {
					searchHeading="072 Brendon Land",
					searchDetail="South Enco Burgh",

				},
				 new SearchDetails () {
					searchHeading="217 Dante Harbours",
					searchDetail="South Enco Burgh",

				},
				 new SearchDetails () {
					searchHeading="072 Brendon Land",
					searchDetail="South Enco Burgh",

				},
				 new SearchDetails () {
					searchHeading="072 Brendon Land",
					searchDetail="South Enco Burgh",

				},

			};
		}
	}



	public class HScrollViewCell2Data
	{

		public string name { get; set; }
		public string profileImage { get; set; }
		public Color strokeColor { get; set; }

	}



	public class HScrollViewCell2 : ContentView
	{



		protected AppImage profileImage;

		protected HScrollViewCell2Data bindedData;
		public object BindedData
		{
			get
			{
				return this.bindedData;
			}
			set
			{
				this.bindedData = (HScrollViewCell2Data)value;
			}
		}

		double peopleListOffset = 10;
		double profileImageWidth = 40;
		double profileImageHeight = 40;
		double profileStrokeWidth = 3.0;
		double peopleNameFontSize = MainPage.PageHeight / 60.636;


		public HScrollViewCell2()
		{

			this.BackgroundColor = Color.Transparent;
			this.Padding = peopleListOffset;




			profileImage = new AppImage()
			{
				WidthRequest = profileImageWidth,
				HeightRequest = profileImageHeight,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Transparent,
				StrokeWidth = profileStrokeWidth,
				StrokeColor = Color.Black,



			};

			profileImage.SetBinding(AppImage.StrokeColorProperty, "strokeColor");



			var profileImageContent = new ContentView
			{


				Content = profileImage,

			};

			Label peopleName = new Label
			{
				VerticalOptions = LayoutOptions.End,

				HorizontalOptions = LayoutOptions.Center,
				FontSize = peopleNameFontSize,

				BackgroundColor = Color.Transparent,



			};

			peopleName.SetBinding(AppLabel.TextProperty, "name");

			var peopleNameContent = new StackLayout
			{


				Children ={
					peopleName
				}
			};

			var viewLayout = new StackLayout()
			{

				Orientation = StackOrientation.Vertical,
				Children =
				{
					profileImageContent, peopleNameContent

				},
				BackgroundColor = Color.Transparent
			};

			Content = viewLayout;

		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			this.bindedData = BindingContext as HScrollViewCell2Data;
			if (this.bindedData != null)
			{
				//string imageSource = "HScrollDemo.Resources." + this.bindedData.icon;
				string imageSource = this.bindedData.profileImage;
				this.profileImage.Source = ImageSource.FromFile(imageSource);
				this.profileImage.HeightRequest = profileImageWidth;
				this.profileImage.WidthRequest = profileImageHeight;
			}
		}


	}



}
