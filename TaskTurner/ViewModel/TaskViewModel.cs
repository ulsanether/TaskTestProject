using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TaskTurner.DataService;
using System.Collections.ObjectModel;
using TaskTurner.Model;
using Task = TaskTurner.Model.Task;
using TaskState = TaskTurner.Model.TaskStatus;
using System.Windows.Input;


namespace TaskTurner.ViewModel {
   internal class TaskViewModel:INotifyPropertyChanged {


      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime DueDate { get; set; }
      public DateTime StartDate { get; set; }
      public TimeSpan timer { get; set; }

      

      public bool IsComplete { get; set; }

      public TimeSpan Timer { get; set; }

      public TaskState TaskState { get; set; }
      public TaskImportance TaskImportance { get; set; }
      public TaskCategory TaskCategory { get; set; }

      public ObservableCollection<TaskCheckList> TaskCheckList { get; set; }

      public ICommand IAddNewTask => new RelayCommand(AddNewTask);


      //This is used to interact with the underlying data storage
      private readonly TaskDataService _taskDataService;

      private ObservableCollection<Task> _tasks;

      public ObservableCollection<Task> Tasks {
         get => _tasks;
         set {
            _tasks = value;
            OnPropertyChanged(nameof(Tasks));
            }
         }


      public event PropertyChangedEventHandler PropertyChanged;


      private void LoadTasks() {
         var TaskList = _taskDataService.LoadTasks();
         Tasks = new ObservableCollection<Task>(TaskList);
         }

      public void AddNewTask() {

         Task newTask = new Task{
            Title = this.Title,
            Description = this.Description,
            Id = _taskDataService.GenerateNewTaskId(),
            DueDate = this.DueDate,
            IsComplete = false,
            StartDate = DateTime.Now,
            TaskCategory = TaskCategory.Education,
            TaskCheckList = this.TaskCheckList,
            TaskImportance = TaskImportance.Critical,
            TaskStte = TaskState.Late,
            Timer = new TimeSpan(0)

            };
         _taskDataService.AddTask(newTask);
         LoadTasks();
         }



       public void UpdateTask(Task updateTask) {
         _taskDataService.UpdateTask(updateTask);
         LoadTasks();
         }


         public void DeleteTask(int taskId) {
         _taskDataService.DeleteTask(taskId);
         LoadTasks();
         }


      public TaskViewModel() {

         _taskDataService = new TaskDataService();  //Initializing the TaskDataService 
         TaskCheckList = new ObservableCollection<TaskCheckList>();


         }

      protected virtual void OnPropertyChanged(string propertyName) {
         PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));

         }
      }


   }