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


        public delegate void DragAddHandler(object sender, EventArgs e);
        public event DragAddHandler ElementAdded;
        public delegate void DragRemoveHanlder(object sender, EventArgs e);
        public event DragRemoveHanlder ElementRemoved;
        public delegate void DragStartHandler(object sender, MouseButtonEventArgs e);
        public event DragStartHandler ElementLifted;
        public delegate void OnDragHandler(object sender, MouseEventArgs e);
        public event OnDragHandler ElementDragged;
        public delegate void DragEndHandler(object sender, MouseButtonEventArgs e);
        public event DragEndHandler ElementDropped;

        public DragCanvas()
        {
            InitializeComponent();
        }
        public void AddDraggable(UIElement draggable, Panel draggableParent,Size offset)
        {
            draggableParent.Children.Remove(draggable);
            dragArm = offset;
            this.dragcontent.Children[0] = draggable;
            DraggableElement = dragcontent.Children[0];
            draggable.MouseMove += ElementDrag;
            draggable.MouseUp += DropElement;
            ElementAdded(DraggableElement, new EventArgs());
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
            Sender.MouseLeftButtonUp -= DropElement;
            Sender.MouseLeftButtonDown += ElementLift;
            ElementDropped(Sender, e);

        }

        private void ElementDrag(object sender, MouseEventArgs e)
        {
            UIElement Sender = sender as UIElement;
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(Sender, e.GetPosition(this).X - dragArm.Width);
                Canvas.SetTop(Sender, e.GetPosition(this).Y - dragArm.Height);
                ElementDragged(sender, e);
            }
            else
            {
                Sender.MouseMove -= ElementDrag;
            }
            
        }

        private void ElementLift(object sender, MouseButtonEventArgs e)
        {
            UIElement Sender = sender as UIElement;
            dragArm = (Size)e.GetPosition(Sender);
            Sender.MouseMove += ElementDrag;
            Sender.MouseLeftButtonDown -= ElementLift;
            Sender.MouseLeftButtonUp += DropElement;
            ElementDropped(sender, e);
        }

    }
}
