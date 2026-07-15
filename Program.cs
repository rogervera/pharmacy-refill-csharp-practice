List<Patient> patients = new List<Patient>();
string addAnotherInput;

do
{
    Console.WriteLine("Enter patient name:");
    string name = Console.ReadLine() ?? "Unknown";

    Console.WriteLine("Enter medication:");
    string medication = Console.ReadLine() ?? "Unknown";

    int daysSinceLastFill;
    bool daysParsedOk;

    do
    {
        Console.WriteLine("Enter days since last fill:");
        string daysInput = Console.ReadLine() ?? "";
        daysParsedOk = int.TryParse(daysInput, out daysSinceLastFill);

        if (!daysParsedOk)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    } while (!daysParsedOk);

    bool hasPriorAuth = false;
    bool priorAuthParsedOk;

    do
    {
        Console.WriteLine("Does the patient have prior authorization? (yes/no):");
        string hasPriorAuthInput = Console.ReadLine() ?? "";

        bool isYes = string.Equals(hasPriorAuthInput, "yes", StringComparison.OrdinalIgnoreCase) || string.Equals(hasPriorAuthInput, "y", StringComparison.OrdinalIgnoreCase);
        bool isNo = string.Equals(hasPriorAuthInput, "no", StringComparison.OrdinalIgnoreCase) || string.Equals(hasPriorAuthInput, "n", StringComparison.OrdinalIgnoreCase);

        priorAuthParsedOk = isYes || isNo;

        if (!priorAuthParsedOk)
        {
            Console.WriteLine("Invalid input. Please enter yes or no.");
        }
        else
        {
            hasPriorAuth = isYes;
        }
    } while (!priorAuthParsedOk);

    Patient patient = new Patient(name, medication)
    {
        DaysSinceLastFill = daysSinceLastFill,
        HasPriorAuth = hasPriorAuth
    };
    patients.Add(patient);

    Console.WriteLine("Add another patient? (y/n):");
    addAnotherInput = Console.ReadLine() ?? "n";
} while (string.Equals(addAnotherInput, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(addAnotherInput, "yes", StringComparison.OrdinalIgnoreCase));

List<Patient> approvedPatients = patients.Where(p => p.GetRejectCode() == RejectCode.None).ToList();

Console.WriteLine($"Approved count: {approvedPatients.Count}");

foreach (Patient patient in approvedPatients)
{
    DeliveryBatch batch = patient.AssignBatch(DateTime.Now.Hour);
    Console.WriteLine($"{patient.Name} assigned to {batch}");
}