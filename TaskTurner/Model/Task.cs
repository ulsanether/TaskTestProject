﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskTurner.Model {
   public class Task {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime DueDate { get; set; }
      public DateTime StartDate { get; set; }
      public TimeSpan timer { get; set; }

      public bool IsComplete { get; set; }

      public TimeSpan Timer { get; set; }


      public TaskStatus TaskStte { get; set; }
      public TaskImportance TaskImportance { get; set; }
      public TaskCategory TaskCategory { get; set; }


      public ObservableCollection<TaskCheckList> TaskCheckList { get; set; } 



      }


   public enum TaskStatus { 
      InProgress,
      Complete,
      NotStarted,
      Late,
      Archived,
      Deleted
   
   
   }

   public enum TaskCategory { 
   
      Work,
      Personal,
      Home,
      HealthWelbeing,
      Finance,
      Shopping,
      SocialFamily,
      Education,
      Travel,
      Errands,
      HobbiesLeisure,
      VolunterringCommunity,
      BirthdaysAnniversaries,
      Projects,
      LongTermGoals
     
   }
   public enum TaskImportance { 
   
     Low,
     Medium,
     High,
     Critical
   
   }
   
   
   }
