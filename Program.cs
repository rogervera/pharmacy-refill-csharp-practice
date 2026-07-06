List<Patient> patients = new List<Patient>();

Patient p1 = new Patient();
p1.Name = "Saul Goodman";
p1.Medication = "Lisinopril";
p1.DaysSinceLastFill = 30;
patients.Add(p1);

Patient pt2 = new Patient();
pt2.Name = "Walter White"; 
pt2.Medication = "Atorvastatin";
pt2.DaysSinceLastFill = 10;
patients.Add(pt2);

List<Patient> approvedPatients = patients.Where(p => !p.IsRefillTooSoon()).ToList();

Console.WriteLine($"Approved count: {approvedPatients.Count}");

foreach (Patient patient in approvedPatients)
{
    DeliveryBatch batch = patient.AssignBatch(DateTime.Now.Hour);
    Console.WriteLine($"{patient.Name} assigned to {batch}");
}

enum DeliveryBatch
{
    OnePM,
    Midnight
}

class Patient
{
    public string Name { get; set; }
    public string Medication { get; set; }
    public int DaysSinceLastFill { get; set; }

    public bool IsRefillTooSoon()
    {
        return DaysSinceLastFill < 27;
    }

    public DeliveryBatch AssignBatch(int currentHour)
    {
        if (currentHour < 12)
        {
            return DeliveryBatch.OnePM;
        }
        else
        {
            return DeliveryBatch.Midnight;
        }
    }
}
