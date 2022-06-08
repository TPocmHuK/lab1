using Lab2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
        public class DeleteModel : PageModel
        {
            public DataListRepositary _dataListRepositary { get; set; }

            public string Title { get; set; }

            public string Type { get; set; }

            public int Rate { get; set; }

            public DeleteModel(DataListRepositary dataListRepositary)
            {
                _dataListRepositary = dataListRepositary;
            }
        
            public void OnPost()
            {
                _dataListRepositary.Remove(Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? ""));
            }
        }
}
