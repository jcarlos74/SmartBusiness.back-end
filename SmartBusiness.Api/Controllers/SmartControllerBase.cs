using Microsoft.AspNetCore.Mvc;


namespace SmartBusiness.Api.Controllers
{
    public class SmartControllerBase : ControllerBase
    {
        //public SearchRequest GetSearchInfo(PagedListRequest loadOptions)
        //{
        //    var searchInfo = new SearchRequest();

        //    var startRowIndex = loadOptions.Start + 1;
        //    var pageSize = loadOptions.Length;
        //    var pageIndex = 1;

        //    if (loadOptions.Start > 1)
        //    {
        //        pageIndex = (startRowIndex + pageSize - 1) / pageSize;
        //    }

        //    searchInfo.Start = startRowIndex;
        //    searchInfo.Draw = pageIndex;
        //    searchInfo.Length = pageSize;
        //    searchInfo.Filter = loadOptions.Columns;

        //    if (loadOptions.Order?.Count > 0)
        //    {
        //        searchInfo.Order = new System.Collections.Generic.List<SortInfo>();

        //        for (int i = 0; i < loadOptions.Order.Count; i++)
        //        {
        //          // searchInfo.Order.Add(new SortInfo() { Column = loadOptions.Order[i].Column, Descending = loadOptions.Order[[i].Desc });
        //        }
        //    }

        //    return searchInfo;
        //}
    }
}
