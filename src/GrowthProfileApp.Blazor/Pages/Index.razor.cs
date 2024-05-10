using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazorise.Charts;
using GrowthProfileApp.Documents;

namespace GrowthProfileApp.Blazor.Pages;

public partial class Index
{
    private RadarChart<double> _mRadarChart;

    private string Notice = "";

    private double AvgScoreA = 0.0D;
    private double AvgScoreB = 0.0D;
    private double AvgScoreC = 0.0D;
    private double AvgScoreD = 0.0D;
    private double AvgScoreE = 0.0D;

    private string[] labels = { "维度A", "维度B", "维度C", "维度D", "维度E" };
    
    List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
    List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };
    
    protected override async Task OnAfterRenderAsync(bool isFirstRender)
    {
        if (isFirstRender && CurrentUser.IsAuthenticated)
        {
            await Refresh();
            
            List<double> dataset = new List<double> { AvgScoreA, AvgScoreB, AvgScoreC, AvgScoreD, AvgScoreE };
            RadarChartDataset<double> radarChartDataset = new RadarChartDataset<double>()
            {
                Label = "各项维度均分",
                Data = dataset,
                
                //BackgroundColor = backgroundColors,
                //BorderColor = borderColors,
                Fill = true,
                //PointRadius = 2,
                //BorderDash = new List<int> { }
            };

            await _mRadarChart.AddLabelsDatasetsAndUpdate(
                labels,
                radarChartDataset
            );
        }
    }

    private async Task Refresh()
    {
        Guid UserId = CurrentUser.Id ?? Guid.Empty;

        int maxA = 0;
        int maxB = 0;
        int maxC = 0;
        int maxD = 0;
        int maxE = 0;

        ProfileDocumentDto? dto1 = await DocService.FindByUserIDAsync(UserId, ProfileDocumentType.TERM_1);
        ProfileDocumentDto? dto2 = await DocService.FindByUserIDAsync(UserId, ProfileDocumentType.TERM_2);
        ProfileDocumentDto? dto3 = await DocService.FindByUserIDAsync(UserId, ProfileDocumentType.TERM_3);
        ProfileDocumentDto? dto4 = await DocService.FindByUserIDAsync(UserId, ProfileDocumentType.TERM_4);

        if (dto1 == null)
        {
            Notice += "第一学年档案未完成！\n";
        }
        else
        {
            maxA += dto1.ScoreA;
            maxB += dto1.ScoreB;
            maxC += dto1.ScoreC;
            maxD += dto1.ScoreD;
            maxE += dto1.ScoreE;
        }
        if (dto2 == null)
        {
            Notice += "第二学年档案未完成！\n";
        }
        else
        {
            maxA += dto2.ScoreA;
            maxB += dto2.ScoreB;
            maxC += dto2.ScoreC;
            maxD += dto2.ScoreD;
            maxE += dto2.ScoreE;
        }
        if (dto3 == null)
        {
            Notice += "第三学年档案未完成！\n";
        }
        else
        {
            maxA += dto3.ScoreA;
            maxB += dto3.ScoreB;
            maxC += dto3.ScoreC;
            maxD += dto3.ScoreD;
            maxE += dto3.ScoreE;
        }
        if (dto4 == null)
        {
            Notice += "第四学年档案未完成！\n";
        }
        else
        {
            maxA += dto4.ScoreA;
            maxB += dto4.ScoreB;
            maxC += dto4.ScoreC;
            maxD += dto4.ScoreD;
            maxE += dto4.ScoreE;
        }

        AvgScoreA = maxA / 4.0;
        AvgScoreB = maxB / 4.0;
        AvgScoreC = maxC / 4.0;
        AvgScoreD = maxD / 4.0;
        AvgScoreE = maxE / 4.0;

        BasicInfoDocumentDto? infoDto = await InfoService.GetByUserAsync(UserId);

        if (infoDto == null)
        {
            Notice += "个人资料未补充！";
        }

        
    }
}
