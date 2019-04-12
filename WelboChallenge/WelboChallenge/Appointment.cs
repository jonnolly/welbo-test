namespace WelboChallenge
{
    public class Appointment
    {
        public Appointment(int appointmentId, string visitorName, string employeeName)
        {
            AppointmentId = appointmentId;
            VisitorName = visitorName;
            EmployeeName = employeeName;
        }

        public int AppointmentId { get; }
        public string VisitorName { get; }
        public string EmployeeName { get; }
    }
}