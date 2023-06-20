using API.BusinessObject.ApiServiceStep;

namespace API.BusinessObject
{
    internal static class ProjectHandler
    {
        public static List<string> projectCodes = new List<string>();

        public static void AddProjectCodeForDelete(string code)
        {
            projectCodes.Add(code);
        }

        public static void DeleteProjects()
        {
            var apiProjectSteps = new ApiProjectSteps();

            foreach (var project in projectCodes)
            {
                apiProjectSteps.DeleteProjectByCode(project);
            }
        }
    }
}
