/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using Hrender3;
using Mirage.SurfaceKit;
using Mirage.TextKit;
using Mirage.UIKit;
using Proxima128.P128;

namespace Mirage.DE
{
    /// <summary>
    /// Test HTML reciever application
    /// Will be replaced w/ DOMforge in the future
    /// </summary>
    class PWeb : UIApplication
    {
        /// <summary>
        /// Initialise the application.
        /// </summary>
        public PWeb(SurfaceManager surfaceManager) : base(surfaceManager)
        {
            MainWindow = new UIWindow(surfaceManager, 800, 600, "ProximaWeb", resizable: false)
            {
                BackgroundColor = GraphicsKit.Color.White
            };
            _textView = new UITextView
            {
                ExplicitSize = MainWindow.Size,
                ExplicitHeight = 25,
                ExplicitWidth = MainWindow.Size.Width - 30,
                Wrapping = false,
                Editable = true,
            };
            _browserView = new UICanvasView(new System.Drawing.Size(MainWindow.Size.Width, MainWindow.Size.Height - 25))
            {
                Location = new System.Drawing.Point(0, 25),
            };

            htmlrender3 renderer = new htmlrender3(new byte[] { } /*replace this with a font*/);
            renderer.ParseHtml("replce this with youre html code");
            renderer.Update((ushort)MainWindow.Size.Width, (ushort)(MainWindow.Size.Height - 25));

            _browserView.Canvas.DrawImage(0,0,BitmapConverter.CGSTOMIRRAGE(renderer.Render()));

            _goButton = new UIButton("Go")
            {
                ExplicitWidth = 30,
                ExplicitHeight = 25,
                Location = new System.Drawing.Point(MainWindow.Size.Width - 30, 0),
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
        private readonly UICanvasView _browserView;
        private readonly UIButton _goButton;

    }
}
