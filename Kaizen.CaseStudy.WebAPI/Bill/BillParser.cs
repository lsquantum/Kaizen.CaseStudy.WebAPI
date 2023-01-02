using System.Text.Json;

namespace Kaizen.CaseStudy.WebAPI.Bill;

public class BillParser
{
    public static string ParseResponseFile()
    {
        string responseJson = File.ReadAllText("response.json");
        List<BillDetail> billDetail= JsonSerializer.Deserialize<List<BillDetail>>(responseJson, new JsonSerializerOptions { 
            PropertyNameCaseInsensitive = true
        });

        billDetail.Remove(billDetail[0]);

        List<BillItem> billItems = new List<BillItem>();
        foreach (var item in billDetail)
        {
            billItems.Add(new BillItem
            { 
                Description = item.Description,
                Line = item.BoundingPoly.Vertices.Max(w => w.Y) 
            });
        }

        billItems = billItems.OrderBy(o => o.Line).ToList();

        string result = "";
        int i = 1;
        for (int j = 0; i < billItems.Count; j++)
        {
            result += billItems[j].Description + " ";
            if (j + 1 == billItems.Count)
                break;
            if (billItems[j + 1].Line - billItems[j].Line > 15)
                result += "\n";
        }

        return result;
    }
}
