using CVCreator.Domain.Entities.Models;
using CVCreator.Domain.Interfaces.Services;
using System.Net;
using Xceed.Words.NET;

namespace CVCreator.Service.Services
{
    public class CVService : ICVService
    {
        public byte[] GenerateCV(CVPayload payload)
        {
			try
			{
                string templatePath = "CV_Template.docx";

                using (DocX document = DocX.Load(templatePath))
                {
                    ReplaceBasicData(payload, document);

                    ReplaceLanguages(payload, document);
                    ReplaceSkills(payload, document);
                    ReplaceExperiences(payload, document);

                    // Save the modified document
                    MemoryStream stream = new MemoryStream();
                    document.SaveAs(stream);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to generate the document", ex);
            }
        }

        private static void ReplaceBasicData(CVPayload payload, DocX document)
        {
            document.ReplaceText("{Name}", payload.Name);
            document.ReplaceText("{Job}", payload.Job);
            document.ReplaceText("{Birth}", payload.Birth);
            document.ReplaceText("{Address}", payload.Address);
            document.ReplaceText("{Email}", payload.Email);
            document.ReplaceText("{Phone}", payload.Phone);
            document.ReplaceText("{Linkedin}", payload.Linkedin);
        }

        private static void ReplaceExperiences(CVPayload payload, DocX document)
        {
            string experiences = "";
            foreach (var experience in payload.Experiences.OrderByDescending(o => o.StartDate))
            {
                var endDate = experience.IsCurrent ? "current" : experience.EndDate;
                experiences += $"{experience.StartDate}-{endDate} - {experience.Company}\n {experience.Description}\n\n";
            }
            document.ReplaceText("{Experiences}", experiences);
        }

        private static void ReplaceSkills(CVPayload payload, DocX document)
        {
            string skills = "";
            foreach (var skill in payload.Skills)
            {
                skills += skill.Name + " " + GetLevelText(skill.Level) + "\n";
            }
            document.ReplaceText("{Skills}", skills);
        }

        private static void ReplaceLanguages(CVPayload payload, DocX document)
        {
            string languages = "";
            foreach (var language in payload.Languages)
            {
                languages += language.Name + " " + GetLevelText(language.Proficiency) + "\n";
            }
            document.ReplaceText("{Languages}", languages);
        }

        private static string GetLevelText(int level)
        {
            var levelText = string.Empty;
            switch (level)
            {
                case 1:
                    levelText = "*";
                    break;
                case 2:
                    levelText = "**";
                    break;
                case 3:
                    levelText = "***";
                    break;
            }

            return levelText;
        }
    }
}
