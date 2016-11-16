using Nancy;
using ToDoList.Objects;
using System.Collections.Generic;
using System;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tasks"] = _ => {
        List<Task> allTasks = Task.GetAll();
        return View["tasks.cshtml", allTasks];
      };
      Get["/tasks/new"] = _ => {
        return View["task_form.cshtml"];
      };
      Post["/tasks"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        List<Task> allTasks = Task.GetAll();
        return View["tasks.cshtml", allTasks];
      };
      Get["/tasks/{id}"] = parameters => {
        Task task = Task.Find(parameters.id);
        return View["task.cshtml", task];
      };
      // Post["/tasks_cleared"] = _ => {
      //   Task.ClearAll();
      //   return View["tasks_cleared.cshtml"];
      // };
    }
  }
}
