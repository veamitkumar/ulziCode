using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UlziUI.Classes.Enums;
using Xamarin.Forms;

namespace UlziUI.Controls
{
	public class AppSearchEntryEditor : ContentView
	{

		#region Static members
		public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(AppSearchEntryEditor), null);
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(AppSearchEntryEditor), Color.Black);
		public static readonly BindableProperty ErrorTextColorProperty = BindableProperty.Create("ErrorTextColor", typeof(Color), typeof(AppSearchEntryEditor), Color.Red);
		public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(AppSearchEntryEditor), Keyboard.Text);
		public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(bool), typeof(AppSearchEntryEditor), default(bool));
		public static readonly BindableProperty AppFontProperty = BindableProperty.Create("AppFont", typeof(AppFonts), typeof(AppSearchEntryEditor), AppFonts.Quicksand);
		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(AppSearchEntryEditor), Entry.FontSizeProperty.DefaultValue);
		public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder", typeof(string), typeof(AppSearchEntryEditor), default(string));
		public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create("PlaceholderColor", typeof(Color), typeof(AppSearchEntryEditor), Entry.PlaceholderColorProperty.DefaultValue);
		public static readonly BindableProperty LineColorProperty = BindableProperty.Create("LineColor", typeof(Color), typeof(AppSearchEntryEditor), Color.White);
		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(AppSearchEntryEditor), default(string));
		public static readonly BindableProperty ErrorImageSourceProperty = BindableProperty.Create("ErrorImageSource", typeof(string), typeof(AppSearchEntryEditor), default(string));
		public static readonly BindableProperty IsErrorProperty = BindableProperty.Create("IsError", typeof(bool), typeof(AppSearchEntryEditor), default(bool));
		public static readonly BindableProperty ImageSizeProperty = BindableProperty.Create("ImageSize", typeof(double), typeof(AppSearchEntryEditor), default(double));
		public static readonly BindableProperty ImageOffsetProperty = BindableProperty.Create("ImageOffset", typeof(double), typeof(AppSearchEntryEditor), default(double));
		#endregion

		private AppEntry _entry = null;
		private Image _leftImage = null;
		private Image _rightImage = null;
		private ContentView _leftImageContent = null;
		private ContentView _rightImageContent = null;

		public AppSearchEntryEditor()
		{

			_entry = new AppEntry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			yourMethod(_entry);
		}


		private void yourMethod(AppEntry _entry)
		{
			_leftImage = new AppImageCommand
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Aspect = Aspect.Fill,
				Source = "left_gray",


			};
			_leftImage.SetBinding(Image.HeightRequestProperty, new Binding("ImageSize", BindingMode.OneWay, null, null, null, this));
			_leftImage.SetBinding(Image.WidthRequestProperty, new Binding("ImageSize", BindingMode.OneWay, null, null, null, this));
			_leftImage.SetBinding(AppImageCommand.CommandProperty, "LeftEntryCommand");




			_leftImageContent = new ContentView
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,

				Content = _leftImage
			};

			//Cakesoft Fixed SB-5
			//Removed repeate initialization of _entry, which is done in contructor.
			_entry.SetBinding(AppEntry.TextProperty, new Binding(TextProperty.PropertyName, BindingMode.TwoWay, null, null, null, this));
			_entry.SetBinding(AppEntry.TextColorProperty, new Binding(TextColorProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.KeyboardProperty, new Binding(KeyboardProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.IsPasswordProperty, new Binding(IsPasswordProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.PlaceholderProperty, new Binding(PlaceholderProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.PlaceholderColorProperty, new Binding(PlaceholderColorProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.AppFontProperty, new Binding(AppFontProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.FontSizeProperty, new Binding(FontSizeProperty.PropertyName, BindingMode.OneWay, null, null, null, this));
			_entry.SetBinding(AppEntry.WidthRequestProperty, new Binding(WidthRequestProperty.PropertyName, BindingMode.OneWay, null, null, null, this));

			_entry.Completed += (sender, args) => {
				this.DoCompleted();
			};
			_entry.Focused += (sender, args) => {
				this.DoFocused();
			};

			_entry.TextChanged += (sender, args) =>
			{
				this.DoTextChanged(sender, args);
			};

			var entryContent = new ContentView
			{

				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness(0, 0, 0, 5),
				Content = _entry
			};

			var _rightImage = new AppImageCommand
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Aspect = Aspect.Fill,


				Source = "plus_gray",
			};
			_rightImage.SetBinding(Image.HeightRequestProperty, new Binding("ImageSize", BindingMode.OneWay, null, null, null, this));
			_rightImage.SetBinding(Image.WidthRequestProperty, new Binding("ImageSize", BindingMode.OneWay, null, null, null, this));
			_rightImage.SetBinding(AppImageCommand.CommandProperty, "RightEntryCommand");

			_rightImageContent = new ContentView
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness(0, 0, 5, 0),
				Content = _rightImage
			};
			var grid = new Grid
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Center,
				RowSpacing = 0,
				ColumnSpacing = 0,
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
				},
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
				}
			};
			grid.Children.Add(_leftImageContent, 0, 0);
			grid.Children.Add(entryContent, 1, 0);
			grid.Children.Add(_rightImageContent, 2, 0);

			var touchGesture = new TapGestureRecognizer();
			touchGesture.Tapped += (sender, args) => {
				_entry.Focus();
			};
			this.GestureRecognizers.Add(touchGesture);

			this.SetColor();


			this.Content = grid;
		}


		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			if (propertyName == ImageSourceProperty.PropertyName)
			{
				this.SetColor();

			}
			else if (propertyName == ErrorImageSourceProperty.PropertyName)
			{
				this.SetColor();

			}
			else if (propertyName == IsErrorProperty.PropertyName)
			{
				this.SetColor();

			}


		}

		public bool SetFocus()
		{
			return _entry.Focus();
		}

		private void SetColor()
		{
			_entry.TextColor = (this.IsError ? this.ErrorTextColor : this.TextColor);

		}




		private void DoCompleted()
		{
			if (this.Completed != null)
				this.Completed(this, EventArgs.Empty);
		}

		private void DoFocused()
		{
			if (this.Focused != null)
				this.Focused(this, EventArgs.Empty);
		}

		private void DoTextChanged(object sender, TextChangedEventArgs ergs)
		{
			if (this.TextChanged != null)
				this.TextChanged(sender, ergs);
		}

		public string Text
		{
			get { return (string)this.GetValue(TextProperty); }
			set { this.SetValue(TextProperty, value); }
		}

		public Color TextColor
		{
			get { return (Color)this.GetValue(TextColorProperty); }
			set { this.SetValue(TextColorProperty, value); }
		}

		public Color ErrorTextColor
		{
			get { return (Color)this.GetValue(ErrorTextColorProperty); }
			set { this.SetValue(ErrorTextColorProperty, value); }
		}

		public Keyboard Keyboard
		{
			get { return (Keyboard)this.GetValue(KeyboardProperty); }
			set { this.SetValue(KeyboardProperty, value); }
		}

		public bool IsPassword
		{
			get { return (bool)this.GetValue(IsPasswordProperty); }
			set { this.SetValue(IsPasswordProperty, value); }
		}

		public AppFonts AppFont
		{
			get { return (AppFonts)this.GetValue(AppFontProperty); }
			set { this.SetValue(AppFontProperty, value); }
		}

		public double FontSize
		{
			get { return (double)this.GetValue(FontSizeProperty); }
			set { this.SetValue(FontSizeProperty, value); }
		}

		public string Placeholder
		{
			get { return (string)this.GetValue(PlaceholderProperty); }
			set { this.SetValue(PlaceholderProperty, value); }
		}

		public Color PlaceholderColor
		{
			get { return (Color)this.GetValue(PlaceholderColorProperty); }
			set { this.SetValue(PlaceholderColorProperty, value); }
		}

		public Color LineColor
		{
			get { return (Color)this.GetValue(LineColorProperty); }
			set { this.SetValue(LineColorProperty, value); }
		}

		public string ImageSource
		{
			get { return (string)this.GetValue(ImageSourceProperty); }
			set { this.SetValue(ImageSourceProperty, value); }
		}

		public string ErrorImageSource
		{
			get { return (string)this.GetValue(ErrorImageSourceProperty); }
			set { this.SetValue(ErrorImageSourceProperty, value); }
		}

		public bool IsError
		{
			get { return (bool)this.GetValue(IsErrorProperty); }
			set { this.SetValue(IsErrorProperty, value); }
		}

		public double ImageSize
		{
			get { return (double)this.GetValue(ImageSizeProperty); }
			set { this.SetValue(ImageSizeProperty, value); }
		}

		public double ImageOffset
		{
			get { return (double)this.GetValue(ImageOffsetProperty); }
			set { this.SetValue(ImageOffsetProperty, value); }
		}

		public event EventHandler Completed;

		public new event EventHandler Focused;

		public event EventHandler<TextChangedEventArgs> TextChanged;
	}

}
