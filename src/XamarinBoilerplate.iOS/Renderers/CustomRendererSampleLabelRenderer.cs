using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinBoilerplate.Core.Controls;
using XamarinBoilerplate.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomRendererSampleLabel), typeof(CustomRendererSampleLabelRenderer))]
namespace XamarinBoilerplate.iOS.Renderers
{
    public class CustomRendererSampleLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && e.OldElement == null) // Indicates that the item has been created.
            {
                // Construction Logic
                NativeView.Alpha = 0.5f;
                NativeView.BackgroundColor = Color.Pink.ToUIColor();
                NativeView.AccessibilityLabel = "This is the screen reader text. You didn't forget about the visually impaired, I trust?";
            }else if (e.NewElement == null && e.OldElement != null) // Indicates that the item has been destroyed.
            {
                // Deconstruction Logic
            }
        }
    }
}