﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.ComponentModel;
using UlziUI.Controls;
using UlziUI.Classes.Enums;
using Android.Graphics;
using UlziUI.Droid.Renderers;

[assembly: ExportRenderer(typeof(AppPicker), typeof(AppPickerRenderer))]
namespace UlziUI.Droid.Renderers
{
    #region AppPickerRenderer
    public class AppPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> args)
        {
            base.OnElementChanged(args);

            if (this.Control != null)
            {
                this.Control.SetBackgroundResource(Resource.Drawable.appentry_data);

                this.SetAppFont();
                this.SetFontSize();
                this.SetHorizontalTextAlignment();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == AppPicker.AppFontProperty.PropertyName)
                this.SetAppFont();
            else if (args.PropertyName == AppPicker.FontSizeProperty.PropertyName)
                this.SetFontSize();
            else if (args.PropertyName == AppPicker.HorizontalTextAlignmentProperty.PropertyName)
                this.SetHorizontalTextAlignment();
        }

        private void SetAppFont()
        {
            var element = (this.Element as AppPicker);

            string path = "";
            if (element.AppFont == AppFonts.Quicksand)
                path = "Fonts/Quicksand-Regular.ttf";

            if (!String.IsNullOrEmpty(path))
            {
                Typeface typeFace = Typeface.CreateFromAsset(this.Context.Assets, path);
                this.Control.Typeface = typeFace;
            }
        }

        private void SetFontSize()
        {
            var view = (this.Element as AppPicker);

            if (view != null)
                this.Control.TextSize = (float)view.FontSize;
        }

        private void SetHorizontalTextAlignment()
        {
            var view = (this.Element as AppPicker);
            var textView = (this.Control as TextView);

            if ((view != null) && (textView != null))
            {
                var gravity = GravityFlags.Start;
                if (view.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Center)
                    gravity = GravityFlags.CenterHorizontal;
                else if (view.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.End)
                    gravity = GravityFlags.End;

                textView.Gravity = gravity;
            }
        }
    }
    #endregion
}