using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using TaskTurner.Model;

using Task = TaskTurner.Model.Task;

namespace TaskTurner.DataService {
   internal class TaskDataService {

      private readonly string _filePath;
      private readonly string folderName = "TaskTurner";

      private readonly string fileName = "tasks.json";


      public TaskDataService() {

         //Get the path to the app data
         string gappDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

         //Get the folder of the application in roaming
         string appFolder = Path.Combine(gappDataPath, folderName);

         //get the data folder inside the app
         string dataFolder = Path.Combine(appFolder, "data");



         //Check f the data folder exists.
         if(!Directory.Exists(dataFolder)) {

            //Create the directory if the folder doeesn.t exist
            Directory.CreateDirectory(dataFolder);

            }
         //DEFINE THE PATH TO THE JSON FILE
         _filePath = Path.Combine(dataFolder,fileName);

         //Ensure the json file exists.

         InitializeFile();


         }

      private void InitializeFile() {

         //check if the file exists
         if(!File.Exists(_filePath)) {
            //
            File.WriteAllText(_filePath,JsonConvert.SerializeObject(new List<Task>()));

            }

         //For Debug purposes
         Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),folderName));
         }


      public List<Task> LoadTasks() {

         //Read and deserialise the JSOn file
         string fileContent = File.ReadAllText(_filePath);
         return JsonConvert.DeserializeObject<List<Task>>(fileContent);

         }


      public void SaveTasks(List<Task> tasks) {
         //Serialise and write the tasks to the JSON file

         string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

         File.WriteAllText(_filePath,json);
         }

      public void AddTask(Task newTask) {


         //Generating a new id number 
         newTask.Id = GenerateNewTaskId();


         //Loading the tasks from the json file
         var tasks = LoadTasks();

         //Adding the new task to the returned string(json string)
         tasks.Add(newTask);
         //Saving the new json string
         SaveTasks(tasks);

         }


      public void UpdateTask(Task updateTask) {


         //Loading the tasks from the json file
         var tasks = LoadTasks();
         //Checking for the id that matches the updateTask id
         var taskIndex= tasks.FindIndex(task =>task.Id == updateTask.Id);

         if(taskIndex != -1) {
            tasks[taskIndex] = updateTask;
            SaveTasks(tasks);
            }
         }


         public void DeleteTask(int taskId) {
         //Loading the tasks from the json file
         var tasks = LoadTasks();

         //checking through for the matching ID, then removing it


         tasks.RemoveAll(t => t.Id == taskId);

         SaveTasks(tasks);


         }  



      //Generate a new task Id by getting the max ID and adding 1 to it.
      public int GenerateNewTaskId() {

         var tasks = LoadTasks();

         if(!tasks.Any()) {
            return 1;

            }

         int maxId = tasks.Max(t => t.Id);

         return maxId + 1;

         }

      }
   }
