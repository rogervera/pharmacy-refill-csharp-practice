List<Patient> patients = new List<Patient>();

Patient p1 = new Patient("Saul Goodman", "Lisinopril");
p1.DaysSinceLastFill = 30;
p1.HasPriorAuth = true;
patients.Add(p1);

Patient pt2 = new Patient("Walter White", "Atorvastatin");
pt2.DaysSinceLastFill = 10;
patients.Add(pt2);

List<Patient> approvedPatients = patients.Where(p => p.GetRejectCode() == RejectCode.None).ToList();

Console.WriteLine($"Approved count: {approvedPatients.Count}");

foreach (Patient patient in approvedPatients)
{
    DeliveryBatch batch = patient.AssignBatch(DateTime.Now.Hour);
    Console.WriteLine($"{patient.Name} assigned to {batch}");
}