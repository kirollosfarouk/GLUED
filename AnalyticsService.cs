using SystemCore;
using APIRequests;
using Messages;
using ServiceLocatorPattern;

namespace Analytics
{
    public class AnalyticsService : IGameService
    {
        private readonly ApiRequestService _apiRequestService;

        public AnalyticsService()
        {
            MessageHub.Subscribe<TinyMessageMcqButtonClicked>(SubmitCourseProgress);
            _apiRequestService = ServiceLocator.Current.Get<ApiRequestService>();
        }

        private void SubmitCourseProgress(TinyMessageMcqButtonClicked message)
        {
            PlayerData playerData = ServiceLocator.Current.Get<PlayerData>();
            _apiRequestService.SubmitCourseProgress(playerData.SelectedCourse.id,
                message.Question.stepID);

            _apiRequestService.SubmitCourseAnalytics(playerData.SelectedCourse.id,
                message.Question.stepID, message.IsTrue, 1, (int) message.Question.score);
        }
    }
}
