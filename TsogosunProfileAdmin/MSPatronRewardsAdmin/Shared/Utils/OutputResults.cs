
namespace MSPatronRewardsAdmin.Shared.Utils
{
    public class OutputResults
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public object Results { get; set; }
    }
}
