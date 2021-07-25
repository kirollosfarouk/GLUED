using System.Collections.Generic;
using System.Linq;
using LevelScenarios;
using MCQ;
using Scenes;
using UnityEngine;

namespace Courses
{ 
    public static class CourseLoader
    {
        public static void LoadCourse(CourseData courseData)
        {
            SceneController.Instance.Load(courseData.environmentScene,
                scene => { CreateScenarioSteps(courseData); });
        }

        private static void CreateScenarioSteps(CourseData courseData)
        {
            var steps = CreateCourseSteps(courseData.courseQuestions,courseData.title);
            CreateDynamicScenarioManager(steps);
        }

        private static void CreateDynamicScenarioManager(IEnumerable<ScenarioStep> steps)
        {
            GameObject scenarioManager = new GameObject();
            Object.Instantiate(scenarioManager);
            DynamicScenario dynamicScenario = scenarioManager.AddComponent<DynamicScenario>();
            dynamicScenario.AddSteps(steps);
        }

        private static IEnumerable<ScenarioStep> CreateCourseSteps(IEnumerable<McqQuestion> questions,string courseName)
        {
            var returnList = new List<ScenarioStep> {ScenarioStepHandler.CreateWelcomeStep(courseName)};
            returnList.AddRange(questions.Select(ScenarioStepHandler.CreateQuestionStep).ToList());
            returnList.Add(ScenarioStepHandler.CreateFeedbackStep());
            
            return returnList;
        }
    }
}
