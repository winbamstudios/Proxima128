/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using Mirage.SurfaceKit;
using Mirage.TextKit;
using Mirage.UIKit;

namespace Mirage.DE
{
    /// <summary>
    /// Test HTML reciever application
    /// </summary>
    class PWeb : UIApplication
    {
        /// <summary>
        /// Initialise the application.
        /// </summary>
        public PWeb(SurfaceManager surfaceManager) : base(surfaceManager)
        {
            MainWindow = new UIWindow(surfaceManager, 320, 240, "ProximaWeb", resizable: false)
            {
                BackgroundColor = GraphicsKit.Color.White
            };
            _textView = new UITextView
            {
                ExplicitSize = MainWindow.Size,
                ExplicitHeight = 215,
                ExplicitWidth = 290,
                Wrapping = false,
                Editable = true,
            };
            _browserView = new UITextView
            {
                Location = new System.Drawing.Point(0, 25),
                ExplicitSize = MainWindow.Size,
                ExplicitHeight = 25,
                Wrapping = false,
                Editable = true,
            };
            _goButton = new UIButton("Go")
            {
                ExplicitWidth = 30,
                ExplicitHeight = 25,
                Location = new System.Drawing.Point(290,0),
                HorizontalPadding = 16,
                Style = new UIMenuBarButtonStyle(),
                HorizontalAlignment = TextAlignment.Center,
            };
            _textView.Content.Style = new TextKit.TextStyle(Resources.Cantarell, GraphicsKit.Color.Black);
            _textView.Content.Append("http://example.com");
            _textView.SelectionStart = _textView.SelectionEnd = _textView.Content.Length;
            MainWindow.RootView.Add(_textView);
            MainWindow.RootView.Add(_browserView);
            MainWindow.RootView.Add(_goButton);
        }

        /// <summary>
        /// The URL bar.
        /// </summary>
        private readonly UITextView _textView;
        private readonly UITextView _browserView;
        private readonly UIButton _goButton;
    }
}
