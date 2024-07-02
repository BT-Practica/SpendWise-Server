namespace SpendWise_Server.Models.DTOs.Incomes
{
    public class IncomesDto
    {
        /*        public int Id { get; set; }*/
        /*        public DateTime RegistrationDate { get; set; }*/
        public string Description { get; set; }
        public bool Reccurence { get; set; }
        public int UserId { get; set; }
        public int Income_CategoryId { get; set; }
    }
}
