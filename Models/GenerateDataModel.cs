namespace AdayaTestWeb.Models
{
    public record GenerateDataModel
    {
        public int Id { get; set; }
        public string Nama { get; set; } = default!;
        /// <summary>
        /// Description :<br/>
        /// 1. Man <br/>
        /// 2. Women
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Description :<br/>
        /// A. Sepakbola <br/>
        /// B. Badminton <br/>
        /// C. Tennis <br/>
        /// D. Renang <br/>
        /// E. Bersepeda 
        /// </summary>
        public string Hobi { get; set; } = default!;
        public int Umur { get; set; }
    }
}
