namespace GestionAcademicaPratice.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public required string  Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
