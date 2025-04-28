namespace DtoLayer.BoatDtos
{
    public class UpdateBoatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }

        public double Size { get; set; }
        public int Capacity { get; set; }
        public int MasterKabin { get; set; }
        public int WcBanyo { get; set; }
        public int Captain { get; set; }
        public int Chef { get; set; }

        public decimal Price { get; set; }

        public List<string> Equipment { get; set; }

        public List<string> Images { get; set; }
        public bool feature { get; set; }
    }
}
