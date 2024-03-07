using Cosmos.System.Graphics;
using Mirage.DE;
using Mirage.UIKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirage.GraphicsKit;
using Mirage.SurfaceKit;
using Mirage;

namespace Proxima128.Utilities
{
    /// <summary>
    /// Error popup application.
    /// </summary>
    public class ErrorPopup
    {
        /// <summary>
        /// Initialise the application.
        /// </summary>
        public ErrorPopup(SurfaceManager surfaceManager, string errorText)
        { 
            UIWindow MainWindow = new UIWindow(surfaceManager, 240, 120, "Error")
            {
                BackgroundColor = Color.White
            };
            _popupText = new UITextView
            {
                ExplicitSize = MainWindow.Size,
                Wrapping = false,
                Editable = false,
            };
            _popupText.Content.Style = new Mirage.TextKit.TextStyle(Resources.Cantarell, Color.Black);
            _popupText.Content.Append(errorText);
            MainWindow.RootView.Add(_popupText);
        }
        /// <summary>
        /// Error popup text
        /// </summary>
        private readonly UITextView _popupText;
    }
}
