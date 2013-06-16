﻿using System;
using System.Collections.Generic;
using AviTracker.Web.Models;
using AviTracker.Web.Models.ContextConfiguration;
using MvcApplication1.Models;

namespace AviTracker.Web.App_Start
{
    public class SeedFactory
    {
        public static void Load(ProjectTrackerContext context)
        {
            var user = new List<UserProfile>
                {
                    new UserProfile {UserName = "test1@gmail.com"},
                    new UserProfile {UserName = "test2@gmail.com"},
                    new UserProfile {UserName = "test3@gmail.com"},
                    new UserProfile {UserName = "test4@gmail.com"},
                };
            foreach (UserProfile profile in user)
            {
                context.UserProfiles.Add(profile);
            }
            var taskTypes = new List<TaskType>
                {
                    new TaskType
                        {
                            TaskTypeName = "Project Discovery"
                        },
                    new TaskType
                        {
                            TaskTypeName = "Research and Design"
                        },
                    new TaskType
                        {
                            TaskTypeName = "Development"
                        },
                    new TaskType
                        {
                            TaskTypeName = "Testing"
                        },
                    new TaskType
                        {
                            TaskTypeName = "Bug Fix"
                        },
                    new TaskType
                        {
                            TaskTypeName = "Deployment"
                        },
                };
            foreach (TaskType type in taskTypes)
            {
                context.TaskTypes.Add(type);
            }

            var timeSheetStatuses = new List<TimeSheetStatus>
                {
                    new TimeSheetStatus {Status = "Not Started"},
                    new TimeSheetStatus {Status = "Pending Information"},
                    new TimeSheetStatus {Status = "Pending Impediment"},
                    new TimeSheetStatus {Status = "Work in Progress"},
                    new TimeSheetStatus {Status = "Completed"},
                    new TimeSheetStatus {Status = "Checked In"}
                };

            foreach (TimeSheetStatus tss in timeSheetStatuses)
            {
                context.TimeSheetStatuses.Add(tss);
            }

            var client = new Client
                {
                    ClientName = "My New Test Project",
                    ContactName = "Mr Phoen Man",
                    EmailAddress = "this@that.com",
                };

            var project = new Project
                {
                    Description = "This is my first project",
                    ProjectName = "My First Project",
                    ProjectTasks = new List<ProjectTask>
                        {
                            new ProjectTask
                                {
                                    TaskName = "Meet with Client",
                                    TaskType = taskTypes[0],
                                    Rate = 100m,
                                    Hours = 5m,
                                    StartDate = DateTime.Today,
                                    Timesheets = new List<Timesheet>
                                        {
                                            new Timesheet
                                                {
                                                    Description = "Work Very Hard Today",
                                                    RevisionNumber = "1000",
                                                    ActualHours = 2,
                                                    StartedAt = DateTime.Now,
                                                    Status = timeSheetStatuses[3],
                                                    User = user[0]
                                                },new Timesheet
                                                {
                                                    Description = "What do I do with this?",
                                                    RevisionNumber = "1001",
                                                    ActualHours = 2.5m,
                                                    StartedAt = DateTime.Now,
                                                    Status = timeSheetStatuses[2],
                                                    User = user[0]
                                                }
                                        }
                                }
                        }
                };
            client.Projects = new List<Project> {project};
            context.Clients.Add(client);
            context.SaveChanges();
        }
    }
}