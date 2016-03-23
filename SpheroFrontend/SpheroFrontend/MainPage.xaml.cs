using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SpheroFrontend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            try
            {
    
            }
            catch { }
            
        }
        List<string> messages = new List<string>();
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.NavigationMode == NavigationMode.New)
            {
                var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync
                    (new Uri("ms-appx:///SpheroCommands.xml"));
                await Windows.Media.SpeechRecognition.VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(storageFile);
            }

            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            dt.Tick += dt_Tick;
            dt.Start();
            
        }
       
        async void dt_Tick(object sender, object e)
        {
            drawGraph(await AzureHelper.getQueueData());
          //lsvData.ItemsSource = messages;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SpheroHelper.parseString(txtCommand.Text);
            
        }
        Point init;
        private void grdCanvas_Loaded(object sender, RoutedEventArgs e)
        {
           init  = new Point(grdCanvas.ActualWidth / 2, grdCanvas.ActualHeight / 2 );
            lneXAxis.X1 = init.X; lneXAxis.X2 = init.X; lneXAxis.Y1 = 0; lneXAxis.Y2 = grdCanvas.ActualHeight;
            lneYAxis.X1 = 0; lneYAxis.X2 = grdCanvas.ActualWidth; lneYAxis.Y1 = init.Y; lneYAxis.Y2 = init.Y;


            //List<Point> points = new List<Point>();
            //points.Add(new Point(110, 0));
            //points.Add(new Point(100, 150));
            //points.Add(new Point(200, 100));

        }
       
        void drawGraph(List<Point> points)
        {
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = init;
            LineSegment lineSeg = new LineSegment();
            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
        
            foreach (var point in AzureHelper.PointData)
            {

                lineSeg = new LineSegment();
                lineSeg.Point = new Point(point.X + init.X, point.Y + init.Y);
                myPathSegmentCollection.Add(lineSeg);
            }
            pthFigure.Segments = myPathSegmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);
            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            arcPath.Stroke = new SolidColorBrush(Windows.UI.Colors.White);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;
        }
    }
}
