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
