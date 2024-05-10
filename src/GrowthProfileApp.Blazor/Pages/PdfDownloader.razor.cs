using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Font;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GrowthProfileApp.Blazor.Pages;

public partial class PdfDownloader : ComponentBase
{
    
    [Inject]
    public IJSRuntime JsRuntime { get; set; }
    
    [Parameter]
    public string tgtId { get; set; }
    
    [Parameter]
    public int term { get; set; }

    private BasicInfoDocumentDto infoDto = new BasicInfoDocumentDto();
    private ProfileDocumentDto docDto = new ProfileDocumentDto();
    private IJSObjectReference _jsModule;

    private ProfileDocumentType type;

    private bool shouldShow = true;

    protected override async Task OnParametersSetAsync()
    {
        switch (term)
        {
            case 1:
                type = ProfileDocumentType.TERM_1;
                break;
            case 2:
                type = ProfileDocumentType.TERM_2;
                break;
            case 3:
                type = ProfileDocumentType.TERM_3;
                break;
            case 4:
                type = ProfileDocumentType.TERM_4;
                break;
        }
        
        BasicInfoDocumentDto? aInfo = await InfoService.GetByUserAsync(Guid.Parse(tgtId));
        ProfileDocumentDto? aDoc = await DocService.FindByUserIDAsync(Guid.Parse(tgtId), type);
        if (aInfo == null || aDoc == null)
        {
            shouldShow = false;
        }
        else
        {
            infoDto = aInfo;
            docDto = aDoc;
        }
        
        _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import","/scripts/blob_download.js");
    }

    private async Task OnDownloadClicked()
    {
        var cont = await GetPdf();
        //var fileName = "学习档案.pdf";
        var fileName = "学习档案.html";
        
        using var fileStream = new MemoryStream(cont);
        using var streamRef = new DotNetStreamReference(stream:fileStream);
        
        await _jsModule.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }

    private async Task<byte[]> GetPdf()
    {
        var info = ResService.GetFileInfo("/PdfResource/uwu.html");
        
        await using var stream = info.CreateReadStream();
        
        using var reader = new StreamReader(stream, Encoding.UTF8, true);
        var htmlTemplate = await reader.ReadToEndAsync();

        htmlTemplate = htmlTemplate.Replace("{{Term}}", term.ToString());
        
        // Info DTO
        htmlTemplate = htmlTemplate.Replace("{{Name}}", infoDto.Name)
            .Replace("{{Nation}}", infoDto.Nation)
            .Replace("{{Birthday}}", infoDto.Birthday.ToString("yyyy/MM/dd"))
            .Replace("{{PoliticalStatus}}", infoDto.PoliticalStatus)
            .Replace("{{Faculty}}", infoDto.Faculty)
            .Replace("{{Profession}}", infoDto.Profession)
            .Replace("{{Class}}", infoDto.Class)
            .Replace("{{Address}}", infoDto.Address)
            .Replace("{{FamilyStatus}}", infoDto.FamilyStatus)
            .Replace("{{FamilyDescription}}", infoDto.FamilyDescription)
            .Replace("{{GrowthEnvironmentDescription}}", infoDto.GrowthEnvironmentDescription)
            .Replace("{{SelfIntroduction}}", infoDto.SelfIntroduction);
        
        htmlTemplate = htmlTemplate.Replace("{{LearningGoal}}", docDto.LearningGoal)
            .Replace("{{ExamGoal}}", docDto.ExamGoal)
            .Replace("{{PoliticalGoal}}", docDto.PoliticalGoal)
            .Replace("{{RoleGoal}}", docDto.RoleGoal)
            .Replace("{{AwardGoal}}", docDto.AwardGoal)
            .Replace("{{ClubGoal}}", docDto.ClubGoal)
            .Replace("{{ReadingGoal}}", docDto.ReadingGoal)
            .Replace("{{SocialCreditGoal}}", docDto.SocialCreditGoal)
            .Replace("{{ExerciseGoal}}", docDto.ExerciseGoal)
            .Replace("{{ShowOffGoal}}", docDto.ShowOffGoal)
            .Replace("{{OtherGoal}}", docDto.OtherGoal)
            .Replace("{{TermSummary}}", docDto.TermSummary)
            .Replace("{{TeacherComment}}", docDto.TeacherComment)
            .Replace("{{ScoreA}}", docDto.ScoreA.ToString())
            .Replace("{{ScoreB}}", docDto.ScoreB.ToString())
            .Replace("{{ScoreC}}", docDto.ScoreC.ToString())
            .Replace("{{ScoreD}}", docDto.ScoreD.ToString())
            .Replace("{{ScoreE}}", docDto.ScoreE.ToString());

        StringBuilder builder = new StringBuilder();
        builder.Append(htmlTemplate);
        
        using (var stringReader = new StringReader(builder.ToString()))
        {
            // var tmpDir = System.IO.Path.GetTempPath();
            // var name = Guid.NewGuid().ToString() + ".pdf";
            // var targetFilename = System.IO.Path.Combine(tmpDir, name);
            //
            // ConverterProperties properties = new ConverterProperties();
            // FontProvider fontProvider = new DefaultFontProvider();
            // fontProvider.AddFont("C:/Windows/Fonts/seguisym.ttf");
            // fontProvider.AddFont("C:/Windows/Fonts/msyh.ttc");
            // fontProvider.AddFont("C:/Windows/Fonts/simsun.ttc");
            // properties.SetFontProvider(fontProvider);
            //
            // HtmlConverter.ConvertToPdf(htmlTemplate, new FileStream(targetFilename, FileMode.Create));
            // return await File.ReadAllBytesAsync(targetFilename);
        }

        return Encoding.UTF8.GetBytes(htmlTemplate);
    }
}