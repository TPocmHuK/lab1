using System.Text.Json;

namespace Lab2.Data;

public class DataListRepositary
{
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    private readonly string _filepath = "Data/TextFile.json";
    public List<DataList> Languages { get; set; } = new();

    public DataListRepositary()
    {
        var _text = File.ReadAllText(_filepath);
        Languages = JsonSerializer.Deserialize<List<DataList>>(_text!) ?? new();
    }

    private void WriteToFile()
    {
        File.WriteAllText(_filepath, JsonSerializer.Serialize(Languages, _options));
    }

    public IList<DataList> List()
    {
        lock (this)
        {
            return Languages;
        }
    }

    /// <summary>
    /// Add new data row
    /// </summary>
    /// <param name="data">New data row</param>
    public void Add(DataList data)
    {
        lock (this)
        {
            data.Id = Guid.NewGuid();

            Languages.Add(data);
            WriteToFile();
        }
    }

    /// <summary>
    /// Update data row
    /// </summary>
    /// <param name="data">Data row</param>
    public void Update(DataList data)
    {
        lock (this)
        {
            var index = Languages.FindIndex(e => e.Id == data.Id);
            Languages[index] = data;

            WriteToFile();
        }
    }

    /// <summary>
    /// Remove data row
    /// </summary>
    /// <param name="id">Row id to remove</param>
    public void Remove(Guid id)
    {
        lock (this)
        {
            var removed = Languages.FirstOrDefault(x => x.Id == id);
            if (removed == null)
            return;

            Languages.Remove(removed);
            WriteToFile();
        }
    }
}
