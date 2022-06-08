using Lab2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class CreateModel : PageModel
    {
        public DataListRepositary _dataListRepositary { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int Rate { get; set; }

        public CreateModel(DataListRepositary dataListRepositary)
        {
            _dataListRepositary = dataListRepositary;
        }

        public void OnPost()
        {
            Title = Request.Form["title"];
            Type = Request.Form["types[]"];
            Rate = int.Parse(Request.Form["rate"]);

            _dataListRepositary.Add(new DataList { Title = Title, Type = Type, Rate = Rate });
        }
    }
}
