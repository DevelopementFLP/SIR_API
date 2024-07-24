namespace SistemaIntegralReportes.Models
{
    public class HorarioEmpleado
    {
        public int Employee {  get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public DateTime Date { get; set; }
        public int Station { get; set; }
        public string StationName { get; set; }
        public DateTime Login {  get; set; }
        public string Logout { get; set; }
        public DateTime Hours { get; set; }
    }
}
