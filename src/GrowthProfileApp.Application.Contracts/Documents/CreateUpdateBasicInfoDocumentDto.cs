using System;
using System.ComponentModel.DataAnnotations;

namespace GrowthProfileApp.Documents;

public class CreateUpdateBasicInfoDocumentDto
{
    [Required] public Guid UserID { get; set; }
    
    [Required] [StringLength(10)] public string Name { get; set; } // 姓名
    [Required] [StringLength(5)] public string Nation { get; set; } // 民族
    [Required] [DataType(DataType.Date)] public DateTime Birthday { get; set; } // 生日
    [Required] [StringLength(5)] public string PoliticalStatus { get; set; } // 政治面貌
    [Required] [StringLength(10)] public string Faculty { get; set; } // 学院
    [Required] [StringLength(10)] public string Profession { get; set; } // 专业
    [Required] [StringLength(10)] public string Class { get; set; } // 班级
    [Required] [StringLength(50)] public string Address { get; set; } // 家庭地址
    [Required] [StringLength(50)] public string FamilyStatus { get; set; } // 家庭状况
    [Required] [StringLength(100)] public string FamilyDescription { get; set; } // 描述自己的家庭
    [Required] [StringLength(100)] public string GrowthEnvironmentDescription { get; set; } // 学习成长环境
    [Required] [StringLength(100)] public string SelfIntroduction { get; set; } // 自我介绍
}