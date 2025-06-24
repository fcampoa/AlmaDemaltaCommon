namespace AlmaDeMalta.Common.Contracts.Overviews;
    public class SaleDashboardOverview
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;
    public int TotalProducts { get; set; } = 0;

}
