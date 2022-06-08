using Lab2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class IndexModel : PageModel
    {
        public List<DataList> Items { get; set; }
        public IndexModel(DataListRepositary repositary)
        {
            Items = repositary.List().ToList();
        }
    }
}
