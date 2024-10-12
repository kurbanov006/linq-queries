using System;
using System.Linq;
using CRM.DataContext;
using CRM.Entities;
using CRM.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

DataContext dataContext = new DataContext();



// --------------------- 1 ------------------------ //
// Найти все проекты, в которых у пользователей больше 5 назначенных задач
// var res = from p in dataContext.Projects
//           join t in dataContext.Tasks on p.ProjectId equals t.ProjectId
//           join u in dataContext.Users on t.AssignedToId equals u.UserId
//           where u.AssignedTasks.Count() > 5
//           select new
//           {
//               Name = p.ProjectName
//           };
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.Name + " ");
// }



// -------------------------------- 2 ----------------------------- //
// Получить список задач, в которых количество комментариев превышает 3, и они были созданы за последние 2 месяца
// var res = from t in dataContext.Tasks
//           join c in dataContext.Comments on t.TaskId equals c.TaskId
//           where t.Comments.Count() > 3 && DateTimeOffset.Now.Month - c.CreatedAt.Month < 2
//           select new
//           {
//               Name = t.TaskName
//           };
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.Name);
// }


// ------------------------- 3 -------------------------- //
// Вывести пользователей, которые создали больше всего проектов за последний год
// var res = from u in dataContext.Users
//           join p in dataContext.Projects on u.UserId equals p.ManagerId
//           orderby u.ManagedProjects.Count
//           select new
//           {
//               Name = u.FirstName
//           };
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.Name);
// }


// ------------------ 4 -------------------------- //
// Найти задачи, которые были назначены на пользователей, но не были обновлены в течение 30 дней






// ---------------------- 5 ----------------------- //
// Получить проекты, в которых все задачи имеют статус "Завершено".
// var res = from p in dataContext.Projects
//           where p.ProjectStatus == ProjectStatus.Completed
//           select p;
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.ProjectStatus);
// }


// ---------------------- 6 ---------------------------- //
// Вывести список пользователей, у которых нет ни одного проекта и ни одной задачи.
// var res = from u in dataContext.Users
//           join t in dataContext.Tasks on u.UserId equals t.AssignedToId
//           join p in dataContext.Projects on u.UserId equals p.ManagerId
//           where u.AssignedTasks.Count() == 0 && u.ManagedProjects.Count() == 0
//           select u;
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.FirstName);
// }


// ---------------- 7 -------------------- //
// Найти все комментарии, оставленные в задачах, которые не завершены, и отсортировать их по дате создания.
// var res = from c in dataContext.Comments
//           join t in dataContext.Tasks on c.TaskId equals t.TaskId
//           where t.Status == CRM.Enums.TaskStatus.InProgress
//           orderby c.CreatedAt
//           select c;
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.CommentId + " " +r.Text);
// }


// --------------- 8 ------------------------ //
// Получить список всех проектов с информацией о среднем количестве задач, связанных с каждым проектом.
// var res = from p in dataContext.Projects
//           join t in dataContext.Tasks on p.ProjectId equals t.ProjectId
//           select new
//           {
//               Name = p.ProjectName,
//               Description = t.Description
//           };
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.Name + " " + r.Description);
// }


// --------------------- 9 -------------------- //
// Найти задачи, в которых прикреплено более 2 вложений и которые были назначены конкретному пользователю.
// var res = from u in dataContext.Users
//           join t in dataContext.Tasks on u.UserId equals t.AssignedToId
//           where u.AssignedTasks.Count() > 2 && t.Status != CRM.Enums.TaskStatus.InProgress
//           select u;
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.FirstName);
// }



// --------------------- 10 ------------------------ //
// Вывести все проекты, у которых дата окончания больше, чем дата создания задачи, но меньше, чем дата создания следующей задачи.
// var res = from p in dataContext.Projects
//           join t in dataContext.Tasks on p.ProjectId equals t.ProjectId
//           where p.EndDate > t.StartDate
//           select p;
// foreach (var r in res)
// {
//     System.Console.WriteLine(r.ProjectName);
// }