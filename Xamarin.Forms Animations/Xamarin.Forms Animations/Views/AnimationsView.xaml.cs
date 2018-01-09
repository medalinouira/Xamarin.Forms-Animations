///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Xamarin.Forms_Animations.Models;
using Xamarin.Forms_Animations.Extensions;

namespace Xamarin.Forms_Animations.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationsView : ContentPage
    {
        public AnimationsView(AnimationType animationType)
        {
            InitializeComponent();
            InitializeView(animationType);
            btnCancelAnimation.Clicked += new EventHandler((sender, args) => this.CancelingAnimation());
            btnInitializePosition.Clicked += new EventHandler((sender, args) => this.InitializePosition());
            btnStartAnimation.Clicked += new EventHandler((sender, args) => this.ExecuteAction(pikAnimationTypes.SelectedItem.ToString()));
        }

        private void SelectedIndexChanged(object sender, EventArgs args)
        {
            btnStartAnimation.IsEnabled = true;
        }

        private void InitializeView(AnimationType animationType)
        {
            Title = animationType + " Animation";
            switch (animationType)
            {
                case AnimationType.Simple:
                    pikAnimationTypes.ItemsSource = new ObservableCollection<string> {
                        "Rotation",
                        "Relative Rotation",
                        "Scaling",
                        "Relative Scaling",
                        "Scaling and Rotation with Anchors",
                        "Translation",
                        "Fading",
                        "Compound Animations",
                        "Composite Animations",
                        "Multiple Animations",
                        "Velocity Animations"
                    };
                    break;

                case AnimationType.Easing:
                    pikAnimationTypes.ItemsSource = new ObservableCollection<string> {
                        "Easing Method",
                        "Easing Func",
                        "Easing Constructor"
                    };
                    break;

                case AnimationType.Custom:
                    pikAnimationTypes.ItemsSource = new ObservableCollection<string> {
                        "Custom Animation",
                        "Extension Method Animation"
                    };
                    break;

                default:
                    break;
            }
            pikAnimationTypes.SelectedIndex = 0;
        }
        private void ExecuteAction(string action)
        {
            switch (action)
            {
                case "Rotation":
                    StartSampleRotationAnimation();
                    break;
                case "Relative Rotation":
                    StartSampleRelativeRotationAnimation();
                    break;
                case "Scaling":
                    StartSampleScalingAnimation();
                    break;
                case "Relative Scaling":
                    StartSampleRelativeScalingAnimation();
                    break;
                case "Scaling and Rotation with Anchors":
                    StartSampleScalingAndRotationWithAnchorsAnimation();
                    break;
                case "Translation":
                    StartSampleTranslationAnimation();
                    break;
                case "Fading":
                    StartSampleFadingAnimation();
                    break;
                case "Compound Animations":
                    StartSampleCompoundAnimation();
                    break;
                case "Composite Animations":
                    StartSampleCompositeAnimation();
                    break;
                case "Multiple Animations":
                    StartSampleMultipleAnimation();
                    break;
                case "Velocity Animations":
                    StartSampleVelocityAnimation();
                    break;
                case "Easing Method":
                    StartEasingMethodAnimation();
                    break;
                case "Easing Func":
                    StartEasingFuncAnimation();
                    break;
                case "Easing Constructor":
                    StartEasingConstructorAnimation();
                    break;
                case "Custom Animation":
                    StartCustomAnimation();
                    break;
                case "Extension Method Animation":
                    StartExtensionMethodAnimation();
                    break;
                case "Initialize Position":
                    InitializePosition();
                    break;
            }
        }
        private async void StartSampleRotationAnimation()
        {
            await imgXFAnimations.RotateTo(360, 1000);
        }
        private async void StartSampleRelativeRotationAnimation()
        {
            await imgXFAnimations.RelRotateTo(360, 1000);
        }
        private async void StartSampleScalingAnimation()
        {
            await imgXFAnimations.ScaleTo(2, 1000);
            await imgXFAnimations.ScaleTo(1, 1000);
        }
        private async void StartSampleRelativeScalingAnimation()
        {
            await imgXFAnimations.RelScaleTo(2, 1000);
            await imgXFAnimations.RelScaleTo(1, 1000);
        }
        private async void StartSampleScalingAndRotationWithAnchorsAnimation()
        {
            imgXFAnimations.AnchorY = (Math.Min(stlContent.Width, stlContent.Height) / 2) / imgXFAnimations.Height;
            await imgXFAnimations.RotateTo(360, 1000);
        }
        private async void StartSampleTranslationAnimation()
        {
            await imgXFAnimations.TranslateTo(-100, -100, 1000);
            await imgXFAnimations.TranslateTo(0, 0, 1000);
        }
        private async void StartSampleFadingAnimation()
        {
            await imgXFAnimations.FadeTo(0, 1000);
            await imgXFAnimations.FadeTo(1, 1000);
        }
        private async void StartSampleCompoundAnimation()
        {
            await imgXFAnimations.TranslateTo(-80, 0, 1000);    // Move image left
            await imgXFAnimations.TranslateTo(-80, -80, 1000);  // Move image up
            await imgXFAnimations.TranslateTo(80, 80, 1000);    // Move image diagonally down and right
            await imgXFAnimations.TranslateTo(0, 80, 1000);     // Move image left
            await imgXFAnimations.TranslateTo(0, 0, 1000);      // Move image up
        }
        private async void StartSampleCompositeAnimation()
        {
            imgXFAnimations.RotateTo(360, 2000);
            await imgXFAnimations.ScaleTo(1.5, 1000);
            await imgXFAnimations.ScaleTo(1, 1000);
        }
        private async void StartSampleMultipleAnimation()
        {
            await Task.WhenAny<bool>
            (
              imgXFAnimations.RotateTo(360, 1000),
              imgXFAnimations.ScaleTo(2, 1000)
            );
            await imgXFAnimations.ScaleTo(1, 1000);
        }
        private async void StartSampleVelocityAnimation()
        {
            await imgXFAnimations.TranslateTo(0, 100, 1000, Easing.BounceIn);
            await imgXFAnimations.ScaleTo(2, 1000, Easing.CubicIn);
            await imgXFAnimations.RotateTo(360, 1000, Easing.SinInOut);
            await imgXFAnimations.ScaleTo(1, 1000, Easing.CubicOut);
            await imgXFAnimations.TranslateTo(0, -100, 1000, Easing.BounceOut);
        }
        private async void StartEasingMethodAnimation()
        {
            await imgXFAnimations.TranslateTo(0, 200, 1000, CustomEase());
        }
        Easing CustomEase()
        {
            return new Easing(t => (int)(5 * t) / 5.0);
        }
        private async void StartEasingFuncAnimation()
        {
            Func<double, double> CustomEase = t => 9 * t * t * t - 13.5 * t * t + 5.5 * t;
            await imgXFAnimations.TranslateTo(0, 200, 1000, CustomEase);
        }
        private async void StartEasingConstructorAnimation()
        {
            await imgXFAnimations.TranslateTo(0, 200, 1000, new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));
        }
        private void StartCustomAnimation()
        {
            var parentAnimation = new Animation();
            var scaleUpAnimation = new Animation(v => imgXFAnimations.Scale = v, 1, 2, Easing.SpringIn);
            var rotateAnimation = new Animation(v => imgXFAnimations.Rotation = v, 0, 360);
            var scaleDownAnimation = new Animation(v => imgXFAnimations.Scale = v, 2, 1, Easing.SpringOut);

            parentAnimation.Add(0, 0.5, scaleUpAnimation);
            parentAnimation.Add(0, 1, rotateAnimation);
            parentAnimation.Add(0.5, 1, scaleDownAnimation);

            parentAnimation.Commit(this, "imgXFCustomAnimation", 16, 4000, null, null);
        }
        private async void StartExtensionMethodAnimation()
        {
            await imgXFAnimations.ColorTo(Color.Blue, Color.Red, c => imgXFAnimations.BackgroundColor = c, 5000);
            await this.ColorTo(Color.FromRgb(0, 0, 0), Color.FromRgb(255, 255, 255), c => BackgroundColor = c, 5000);
        }
        private void CancelingAnimation()
        {
            ViewExtensions.CancelAnimations(imgXFAnimations);
        }
        private async void InitializePosition()
        {
            this.AbortAnimation("imgXFCustomAnimation");
            this.CancelingAnimation();
            await Task.WhenAny<bool>
            (
                  imgXFAnimations.RotateTo(0, 1000),
                  imgXFAnimations.TranslateTo(0, 0, 1000),
                  imgXFAnimations.ScaleTo(1, 1000)
            );
        }
    }
}