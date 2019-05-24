using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO5.Models
{
    public class ListViewModel
    {
        public List<TItemSourceList> lists;

        public int Id { get; set; }

        public string SearchSourceName { get; set; }

        //下拉框的值
        public SelectList GatherUrls;

        //下拉框绑定的属性
        public string IsGatherUrlNull { get; set; }

        //此属性名称必须和控制器的参数名称一致，输入参数值做对应查询的时候，才会自动绑定到界面上
        public string SearchGatherUrl { get; set; }

   
    }
}
