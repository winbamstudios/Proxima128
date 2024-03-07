/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using Hrender3;
using Mirage.SurfaceKit;
using Mirage.TextKit;
using Mirage.UIKit;
using Proxima128.P128;
using CosmosHttp.Client;
using System.IO;

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
            MainWindow = new UIWindow(surfaceManager, 800, 600, "DOMforge", resizable: false)
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
            
            htmlrender3 renderer = new htmlrender3(Resources.CantarellTTF);
            renderer.ParseHtml("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>Home</title>\r\n</head>\r\n<body>\r\n    <h1>Welcome to DOMforge</h1>\r\n    <p>Enter a URL and connect to the 'net! (WIP)</p>\r\n</body>\r\n</html>");
            renderer.Update((ushort)MainWindow.Size.Width, (ushort)(MainWindow.Size.Height - 25));

            _browserView.Canvas.DrawImage(0, 0, BitmapConverter.CGSTOMIRRAGE(renderer.Render()));

            _goButton = new UIButton("Go")
            {
                ExplicitWidth = 30,
                ExplicitHeight = 25,
                Location = new System.Drawing.Point(MainWindow.Size.Width - 30, 0),
                HorizontalPadding = 16,
                Style = new UIMenuBarButtonStyle(),
                HorizontalAlignment = TextAlignment.Center,
            };

            _goButton.OnMouseClick.Bind((args) => LoadUrl(_textView.Content.Text));

            _textView.Content.Style = new TextKit.TextStyle(Resources.Cantarell, GraphicsKit.Color.Black);
            _textView.Content.Append("http://example.com");
            _textView.SelectionStart = _textView.SelectionEnd = _textView.Content.Length;
            MainWindow.RootView.Add(_textView);
            MainWindow.RootView.Add(_browserView);
            MainWindow.RootView.Add(_goButton);
        }

        private void LoadUrl(string url)
        {
            _request = new HttpRequest();
            _request.IP = "34.223.124.45";
            _request.Domain = url; //very useful for subdomains on same IP
            _request.Path = "/";
            _request.Method = "GET";
            _request.Send();
            htmlrender3 renderer = new htmlrender3(Resources.CantarellTTF);
            renderer.ParseHtml(_request.Response.Content);
            renderer.Update((ushort)MainWindow.Size.Width, (ushort)(MainWindow.Size.Height - 25));

        }

        /// <summary>
        /// The URL bar.
        /// </summary>
        private readonly UITextView _textView;
        private readonly UICanvasView _browserView;
        private readonly UIButton _goButton;
        private HttpRequest _request;
    }
}