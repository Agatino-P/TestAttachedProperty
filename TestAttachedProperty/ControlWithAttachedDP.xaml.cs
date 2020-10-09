using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;

namespace TestAttachedProperty
{
    /// <summary>
    /// Interaction logic for ControlWithAttachedDP.xaml
    /// </summary>
    public partial class ControlWithAttachedDP : UserControl
    {


        public int DPCounter
        {
            get => (int)GetValue(DPCounterProperty);
            set => SetValue(DPCounterProperty, value);
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
            DependencyProperty.RegisterAttached("AttachedDP", typeof(int), typeof(ControlWithAttachedDP), new PropertyMetadata(null));



        public RelayCommand<int> RCDP
        {
            get { return (RelayCommand<int>)GetValue(RCDPProperty); }
            set { SetValue(RCDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RCDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RCDPProperty =
            DependencyProperty.Register("RCDP", typeof(RelayCommand<int>), typeof(ControlWithAttachedDP), new PropertyMetadata(null));



        public static RelayCommand<int> GetAttachedRC(DependencyObject obj)
        {
            return (RelayCommand<int>)obj.GetValue(AttachedRCProperty);
        }

        public static void SetAttachedRC(DependencyObject obj, RelayCommand<int> value)
        {
            obj.SetValue(AttachedRCProperty, value);
        }
        public static readonly DependencyProperty AttachedRCProperty =
            DependencyProperty.RegisterAttached("AttachedRC", typeof(RelayCommand<int>), typeof(ControlWithAttachedDP), new PropertyMetadata(null));



        public ControlWithAttachedDP()
        {
            InitializeComponent();
        }

        private void CWADP_Loaded(object sender, RoutedEventArgs e)
        {
            if (Content == null)
            {
                return;
            }

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

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            int attachedValue = GetAttachedDP(sender as Button);
            var relayCommand = GetAttachedRC(sender as Button);
            if (relayCommand != null)
            {
                relayCommand.Execute(attachedValue);
            }
        }
    }
}
