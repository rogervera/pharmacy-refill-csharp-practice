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

enum DeliveryBatch
{
    OnePM,
    Midnight
}

enum RejectCode
{
    Unspecified,
    None,
    RefillTooSoon,
    PriorAuthRequired,
    NonMatchedCardholder,
}

class Patient(string name, string medication)
{
    public string Name { get; set; } = name;
    public string Medication { get; set; } = medication;
    public int DaysSinceLastFill { get; set; }

    public bool HasPriorAuth { get; set; }

    private bool IsRefillTooSoon()
    {
        return DaysSinceLastFill < 27;
    }

    public RejectCode GetRejectCode()
    {
        if (!HasPriorAuth)
        {
            return RejectCode.PriorAuthRequired;
        }
        else if (IsRefillTooSoon())
        {
            return RejectCode.RefillTooSoon;
        }
        return RejectCode.None;
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
