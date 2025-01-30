using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         }
      }
   }
