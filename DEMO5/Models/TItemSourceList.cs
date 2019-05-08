using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEMO5.Models
{   

    public partial class TItemSourceList
    {
        [Display(Name ="有效性")]
        public bool? Valid { get; set; }

        [Key]
        public int Id { get; set; }

        [Display(Name = "运营中心ID")]
        public int OpcId { get; set; }

        [Display(Name = "信息类别")]
        public byte Class { get; set; }

        [Display(Name = "省份ID")]
        public int WdId { get; set; }

        [Display(Name = "采集栏目")]
        public string SourceName { get; set; }

        [Display(Name = "原始网址")]
        public string SourceUrl { get; set; }

        [Display(Name = "采集网址")]
        public string GatherUrl { get; set; }

        [Display(Name = "列表参数1")]
        public string ListP1 { get; set; }

        [Display(Name = "列表参数2")]
        public string ListP2 { get; set; }

        [Display(Name = "剩余参数")]
        public string ParamResidual { get; set; }

        [Display(Name = "起始页码")]
        public byte? FirstPage { get; set; }

        [Display(Name = "采集页数")]
        public short? GatherPages { get; set; }

        [Display(Name = "列表总页数")]
        public short? TotalPages { get; set; }

        [Display(Name = "是否采集所有")]
        public bool? IsGatherAllPages { get; set; }

        [Display(Name = "匹配样式")]
        public string ListPattern { get; set; }

        [Display(Name = "字符集")]
        public string ListCharset { get; set; }

        [Display(Name = "网址构成")]
        public string InfoUrl { get; set; }

        [Display(Name = "是否POST提交")]
        public bool? ListIspost { get; set; }

        [Display(Name = "是否采集信息页")]
        public bool? IsGatherInfopages { get; set; }

        [Display(Name = "新增时间")]
        public DateTime? Addtime { get; set; }

        [Display(Name = "每页条数")]
        public int? CntPerPage { get; set; }

        [Display(Name = "是否通用网址")]
        public bool? IsGenericGatherUrl { get; set; }

        [Display(Name = "列表开始")]
        public string ListBegin { get; set; }

        [Display(Name = "列表结束")]
        public string ListEnd { get; set; }

        [Display(Name = "用户EXCELID")]
        public int? Userid { get; set; }

        [Display(Name = "起始页比例")]
        public int? FirstPageRatio { get; set; }

        [Display(Name = "起始页增量")]
        public int? FirstPagePlus { get; set; }

        [Display(Name = "请求头部")]
        public string RequestHeaders { get; set; }

     
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]//数据格式显示样式
        [Display(Name = "修改时间")]
        public DateTime? ModifyDate { get; set; } /*= DateTime.Now.ToLocalTime();*/
    }
}
