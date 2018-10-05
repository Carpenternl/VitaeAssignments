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
        private Size dragArm;
        private UIElement DraggableElement;

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
            DragCanvas DC = d as DragCanvas;

            DC.dragcontent.Children.Clear();
            if(e.NewValue != null)
            {
            DC.dragcontent.Children.Add(e.NewValue as UserControl);
            }
        }

        public delegate void DragAddHandler(object sender, EventArgs e);
        public event DragAddHandler ElementAdded;
        public delegate void DragRemoveHanlder(object sender, EventArgs e);
        public event DragRemoveHanlder ElementRemoved;
        public delegate void OnDragHandler(object sender, MouseEventArgs e);
        public event OnDragHandler DragQuery;
        public delegate void DragEndHandler(object sender, MouseButtonEventArgs e);
        public event DragEndHandler ElementDropped;


        public DragCanvas()
        {
            InitializeComponent();
        }

        public void RemoveDraggable()
        {
            UIElement elementToRemove = DraggableElement;
            this.dragcontent.Children.Remove(DraggableElement);
            ElementRemoved(elementToRemove, new EventArgs());
        }

        private void DropElement(object sender, MouseButtonEventArgs e)
        {
            UIElement Sender = sender as UIElement;
        }



        public void StartDragDrop(UserControl Target,Size s)
        {
            ((Panel)Target.Parent).Children.Remove(Target);
            dragArm = s;
            MyDraggableElement = Target;
            this.PreviewMouseMove += OnPrevMouseMoveDragElement;
            this.IsHitTestVisible = true;
        }

        // Drag The Element To the Mouse Location
        private void OnPrevMouseMoveDragElement(object sender, MouseEventArgs e)
        {
            
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(MyDraggableElement, e.GetPosition(this).X - dragArm.Width);
                Canvas.SetTop(MyDraggableElement, e.GetPosition(this).Y - dragArm.Height);
                //The Element Has Moved, Check if the Element is hovering over the Playing field
               DragQuery(sender, e);
            }
            else
            {
                this.PreviewMouseMove -= OnPrevMouseMoveDragElement;
                this.IsHitTestVisible = false;
            }

            e.Handled = true;
        }
    }
}
