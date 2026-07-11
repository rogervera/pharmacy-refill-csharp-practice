List<Patient> patients = new List<Patient>();

Console.WriteLine("Enter patient name:");
string name = Console.ReadLine() ?? "Unknown";

Console.WriteLine("Enter medication:");
string medication = Console.ReadLine() ?? "Unknown";

Console.WriteLine("Enter days since last fill:");
string daysInput = Console.ReadLine() ?? "";
int daysSinceLastFill;
if (!int.TryParse(daysInput, out daysSinceLastFill))
{
    daysSinceLastFill = 0;
}

Console.WriteLine("Does the patient have prior authorization? (yes/no):");
string hasPriorAuthInput = Console.ReadLine() ?? "no";
bool hasPriorAuth = string.Equals(hasPriorAuthInput, "yes", StringComparison.OrdinalIgnoreCase) || string.Equals(hasPriorAuthInput, "y", StringComparison.OrdinalIgnoreCase);

Patient p1 = new Patient(name, medication)
{
    DaysSinceLastFill = daysSinceLastFill,
    HasPriorAuth = hasPriorAuth
};
patients.Add(p1);

List<Patient> approvedPatients = patients.Where(p => p.GetRejectCode() == RejectCode.None).ToList();

Console.WriteLine($"Approved count: {approvedPatients.Count}");

foreach (Patient patient in approvedPatients)
{
    DeliveryBatch batch = patient.AssignBatch(DateTime.Now.Hour);
    Console.WriteLine($"{patient.Name} assigned to {batch}");
}