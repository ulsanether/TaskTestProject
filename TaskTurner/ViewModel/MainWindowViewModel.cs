using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using TaskTurner.View;

namespace TaskTurner.ViewModel {
   internal class MainWindowViewModel:INotifyPropertyChanged {

      public event PropertyChangedEventHandler PropertyChanged;
      public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);

      private void OpenNewWindow() {

         NewTaskWindow newTaskWindow = new NewTaskWindow();

         newTaskWindow.Show();


         }

      protected virtual void OnPropertyChanged(string propertyName) { 
      
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      
      }
      }
   }
