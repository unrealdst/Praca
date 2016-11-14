using System.Collections.Generic;

namespace ScrumTableService.DomainModels
{
    public class CreateTaskViewModelDateDomainModel
    {
        public IEnumerable<DropDownItemListDomainModel<int, string>> Projects { get; set; }

        public IEnumerable<DropDownItemListDomainModel<string, string>> Users { get; set; }
    }
}