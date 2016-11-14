namespace ScrumTableService.DomainModels
{
    public class DropDownItemListDomainModel<TId, TVal>
    {
        public TId Id { get; set; }
        public TVal Value { get; set; }
    }
}