using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab2.Data;

namespace Lab2.Pages
{
    public class UpdateModel : PageModel
    {
        public DataListRepositary _dataListRepositary { get; set; }

        public Guid? Guid { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Rate { get; set; }

        public UpdateModel(DataListRepositary dataListRepositary)
        {
            _dataListRepositary = dataListRepositary;
        }

        public void OnGet()
        {
            try
            {
                Guid = System.Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? "");
            }
            catch
            {
                Guid = null;
            }

            if (Guid != null)
            {
                var Item = _dataListRepositary.Languages.FirstOrDefault(e => e.Id == Guid) ?? new();

                Title = Item.Title;
                Type = Item.Type;
                Rate = Item.Rate;
            }
        }
        public void OnPost()
        {
            Title = Request.Form["title"];
            Type = Request.Form["types[]"];
            Rate = int.Parse(Request.Form["rate"]);

            Guid tempGuid = System.Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? "");
            _dataListRepositary.Update(new DataList { Id = tempGuid, Title = Title, Type = Type, Rate = Rate });
        }
    }
}
