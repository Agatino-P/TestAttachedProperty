using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TestAttachedProperty
{
    public class MainWindowViewModel:ViewModelBase
    {
        private RelayCommand<int> _mbCmd;
        public RelayCommand<int> MBCmd => _mbCmd ?? (_mbCmd = new RelayCommand<int>(
            (s) => mb(s),
            (s) => true,
			keepTargetAlive:true
            ));

        private void mb(int i)
        {
            MessageBox.Show(i.ToString());
        }
    }
}
