using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskTurner.ViewModel {
   internal class MainWindowViewModel:INotifyPropertyChanged {

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged(string propertyName) { 
      
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      
      }
      }
   }
