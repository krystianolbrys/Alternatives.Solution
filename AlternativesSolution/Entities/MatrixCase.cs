using System.Collections.Generic;

namespace AlternativesSolution.Entities
{
    public class MatrixCase
    {
        public int Id { get; set; }
        public bool IsYourLaptopFast { get; set; }
        public bool IsYourCarTurboCharged { get; set; }

        public IReadOnlyList<Alternative> Alternatives { get; set; }
    }
}
