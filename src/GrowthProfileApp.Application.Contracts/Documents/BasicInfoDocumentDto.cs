using System;
using Volo.Abp.Application.Dtos;

namespace GrowthProfileApp.Documents;

public class BasicInfoDocumentDto : AuditedEntityDto<Guid>
{
    public Guid UserID { get; set; }
    
    public string Name { get; set; } // 姓名
    public string Nation { get; set; } // 民族
    public DateTime Birthday { get; set; } // 生日
    public string PoliticalStatus { get; set; } // 政治面貌
    public string Faculty { get; set; } // 学院
    public string Profession { get; set; } // 专业
    public string Class { get; set; } // 班级
    public string Address { get; set; } // 家庭地址
    public string FamilyStatus { get; set; } // 家庭状况
    public string FamilyDescription { get; set; } // 描述自己的家庭
    public string GrowthEnvironmentDescription { get; set; } // 学习成长环境
    public string SelfIntroduction { get; set; } // 自我介绍
}