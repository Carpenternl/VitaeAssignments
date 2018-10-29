using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShipGame
{
    /// <summary>
    /// Interaction logic for DragCanvas.xaml
    /// </summary>
    public partial class DragCanvas : UserControl
    {


        public Size MouseOffset
        {
            get { return (Size)GetValue(MouseOffsetProperty); }
            set { SetValue(MouseOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseOffsetProperty =
            DependencyProperty.Register("MouseOffset", typeof(Size), typeof(DragCanvas), new PropertyMetadata(new Size(.5,.5)));

        public UserControl MyDraggableElement
        {
            get { return (UserControl)GetValue(MyDraggableElementProperty); }
            set { SetValue(MyDraggableElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDraggableElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDraggableElementProperty =
            DependencyProperty.Register("MyDraggableElement", typeof(UserControl), typeof(DragCanvas), new PropertyMetadata(null,DraggableChanged));

        /// <summary>
        /// Occurs whenever the draggableElement is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void DraggableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DragCanvas Target = d as DragCanvas;

            Target.dragcontent.Children.Clear();
            if(e.NewValue != null)
            {
                Target.Visibility = Visibility.Visible;
            Target.dragcontent.Children.Add(e.NewValue as UserControl);
            }
            else
            {
                Target.Visibility = Visibility.Hidden;
            }
        }

        public DragCanvas()
        {
            InitializeComponent();
        }



        public delegate void OnDrag(object sender, MouseEventArgs e);
        public event OnDrag Drag;
        public delegate void DragStopHandler(object sender, MouseEventArgs e);
        public event DragStopHandler DragStop;

        private void DragQuery(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragCanvas Target = sender as DragCanvas;
                Point CursorLocation = e.GetPosition(Target);
                Size n = Target.RenderSize;
                double OffsetX = CursorLocation.X - (double)MyDraggableElement.ActualWidth * MouseOffset.Width;
                double OffsetY = CursorLocation.Y - (double)MyDraggableElement.ActualHeight * MouseOffset.Height;
                Canvas.SetLeft(MyDraggableElement, OffsetX);
                Canvas.SetTop(MyDraggableElement, OffsetY);
                Drag(MyDraggableElement, e);
            }
            else
            {

                UserControl Data = MyDraggableElement;
                MyDraggableElement = null;
                DragStop(Data, e);
                
            }
        }
    }
}
