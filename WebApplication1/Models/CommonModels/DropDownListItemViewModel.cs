namespace WebApplication1.Models.CommonModels
{
    public class DropDownListItemViewModel<TId, TVal>
    {
        public TId Id { get; set; }
        public TVal Value { get; set; } 
    }
}