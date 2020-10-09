using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAttachedProperty
{
    /// <summary>
    /// Interaction logic for ControlWithAttachedDP.xaml
    /// </summary>
    public partial class ControlWithAttachedDP : UserControl
    {


        public int DPCounter
        {
            get { return (int)GetValue(DPCounterProperty); }
            set { SetValue(DPCounterProperty, value); }
        }
        public static readonly DependencyProperty DPCounterProperty =
            DependencyProperty.Register("DPCounter", typeof(int), typeof(ControlWithAttachedDP), new PropertyMetadata(0));



        public static int GetAttachedDP(DependencyObject obj)
        {
            return (int)obj.GetValue(AttachedDPProperty);
        }

        public static void SetAttachedDP(DependencyObject obj, int value)
        {
            obj.SetValue(AttachedDPProperty, value);
        }
        public static readonly DependencyProperty AttachedDPProperty =
            DependencyProperty.RegisterAttached("AttachedDP", typeof(int), typeof(ControlWithAttachedDP), new PropertyMetadata(0));


        public ControlWithAttachedDP()
        {
            InitializeComponent();
        }

        private void CWADP_Loaded(object sender, RoutedEventArgs e)
        {
            if (Content == null)
                return;

            Panel panel = Content as Panel;

            if (panel != null)
            {
                DPCounter += GetAttachedDP(panel);
                foreach (FrameworkElement child in panel.Children)
                {
                    DPCounter += GetAttachedDP(child);
                }
            }
            else
            {
                DPCounter += GetAttachedDP(Content as DependencyObject);
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            int oldValue = GetAttachedDP(sender as Button);
            MessageBox.Show(oldValue.ToString());
            oldValue++;
            SetAttachedDP((sender as Button), oldValue);
        }
    }
}
