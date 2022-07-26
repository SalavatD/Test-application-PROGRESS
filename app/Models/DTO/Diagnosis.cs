namespace app.Models.DTO
{
    public class Diagnosis
    {
        public Diagnosis(string icd10Code, string name)
        {
            Icd10Code = icd10Code;
            Name = name;
        }
        public string Icd10Code { get; }
        public string Name { get; }
    }
}