namespace Kaizen.CaseStudy.WebAPI.Bill
{
    public class BillDetail
    {
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }

    public class BoundingPoly 
    {
        public List<Vertex> Vertices { get; set; }
    }

    public class Vertex 
    { 
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class BillItem
    {
        public string Description { get; set; }
        public int Line { get; set; }
    }
}
